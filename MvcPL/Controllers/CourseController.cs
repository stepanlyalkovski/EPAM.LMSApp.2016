﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interfaces.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models;
using MvcPL.Models.CourseModels;

namespace MvcPL.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly IStorageService _storageService;
        private readonly ICourseService _courseService;
        private readonly IUserService _userService;
        private readonly IModuleService _moduleService;
        private readonly IEnrolmentService _enrolmentService;
        private string _searchField = String.Empty;
        private string _tags = String.Empty;
        public CourseController(IStorageService storageService, ICourseService courseService, IUserService userService, IModuleService moduleService, IEnrolmentService enrolmentService)
        {
            _storageService = storageService;
            _courseService = courseService;
            _userService = userService;
            _moduleService = moduleService;
            _enrolmentService = enrolmentService;
        }

        // GET: Course

        public ActionResult Index(string searchField, string tags, int page = 1, bool randMode = true)
        {
            ViewBag.Title = "Courses";
            int userId = _userService.GetUserEntity(User.Identity.Name).Id;
            ViewBag.Id = userId;
            IEnumerable<CourseBaseViewModel> courses;
            int pageSize = 5;

            if (randMode)
            {
                int courseNumber = pageSize;

                courses = _courseService.GetRandom(courseNumber).Select(c => c.ToCourseBaseViewModel())
                                                                .ToList();
            }
            else
            {
                string search = String.Empty;
                string tagSearch = String.Empty;

                if (String.IsNullOrEmpty(tags) && String.IsNullOrEmpty(searchField))
                {
                    if (Session["searchField"] != null)
                        search = (string) Session["searchField"];
                    if (Session["tags"] != null)
                        tagSearch = (string) Session["tags"];
                }
                else
                {
                    search = searchField;
                    Session["searchField"] = searchField;
                    tagSearch = tags;
                    Session["tags"] = tags;
                }

                courses = _courseService.Search(search, tagSearch?.Split(',')).Select(c => c.ToCourseBaseViewModel())
                                                                          .ToList();
            }

            var courseList = GetPageCourseList(courses, page, pageSize);
            foreach (var course in courseList.Courses)
            {
                course.EnrolmentInfo = GetCourseEnrolmentInfo(userId, course.Id);
                if (userId == course.UserStorageId)
                {
                    course.IsEditable = true;
                }
            }

            courseList.PageUrl = courseList.PageUrl = x => Url.Action("Index", "Course", new { page = x, randMode = false});
            

            if (Request.IsAjaxRequest())
            {
                return PartialView("_CourseBaseList", courseList);
            }

            return View(courseList);
        }

        [Authorize(Roles = "Manager")]
        public ActionResult ManageList(int page = 1)
        {
            int storageId = _userService.GetUserEntity(User.Identity.Name).Id;
            int pageSize = 5;

            var courses = _courseService.GetCreatedCourses(storageId).Select(c =>
            {
                var course = c.ToCourseBaseViewModel();
                course.IsEditable = true;
                return course;
            }).ToList();

            var courseList = GetPageCourseList(courses, page, pageSize);
            courseList.PageUrl = x => Url.Action("ManageList", "Course", new {page = x});

            if (Request.IsAjaxRequest())
            {
                return PartialView("_CourseBaseList", courseList);

            }
            return View(courseList);
            
        }

        public ActionResult MyCourseList(int page = 1)
        {
            int userId = _userService.GetUserEntity(User.Identity.Name).Id;
            var enrolments = _enrolmentService.GetStudentEnrolments(userId);
            var courses = new List<CourseBaseViewModel>();
            foreach (var enrolment in enrolments)
            {
                var course = _courseService.Get(enrolment.CourseId).ToCourseBaseViewModel();
                course.IsEditable = false;
                courses.Add(course);
            }
            int pageSize = 5;

            var courseList = GetPageCourseList(courses, page, pageSize);
            courseList.PageUrl = x => Url.Action("MyCourseList", "Course", new { page = x });

            foreach (var course in courseList.Courses)
            {
                course.EnrolmentInfo = GetCourseEnrolmentInfo(userId, course.Id);
                if (userId == course.UserStorageId)
                {
                    course.IsEditable = true;
                }
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("_CourseBaseList", courseList);

            }
            return View(courseList);

        }

        [Authorize(Roles = "Manager")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Content(int courseId)
        {
            var modules = _moduleService.GetCourseModules(courseId).Select(m => m.ToModuleBaseViewModel()).ToList();
            var course = _courseService.Get(courseId).ToCourseBaseViewModel();
            int userId = _userService.GetUserEntity(User.Identity.Name).Id;
            course.EnrolmentInfo = GetCourseEnrolmentInfo(userId, courseId);

            if (userId == course.UserStorageId)
            {
                course.IsEditable = true;
            }

            foreach (var module in modules)
            {
                module.EnrolmentInfo = GetModuleEnrolmentInfo(course.EnrolmentInfo.Id, module.Id);

                if (userId == course.UserStorageId)
                {
                    module.IsEditable = true;
                }
                
            }

            var fullCourse = new CourseFullViewModel(course, modules);

            return View(fullCourse);
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public ActionResult Create(CourseCreateViewModel courseModel)
        {
            if (ModelState.IsValid)
            {
                int userId = _userService.GetUserEntity(User.Identity.Name).Id;
                courseModel.UserStorageId = userId;
                _courseService.AddCourse(courseModel.ToCourseEntity());
                var dbCourse = _courseService.GetByTitle(courseModel.Title);
                //_storageService.AddCourse(userId, courseModel.ToCourseEntity());
                return RedirectToAction("Content", "Course", new {courseId = dbCourse.Id});
            }
            return View(courseModel);
        }

        [HttpGet]
        public ActionResult Delete(int courseId)
        {
            var course = _courseService.Get(courseId).ToCourseBaseViewModel();
            if (course == null)
                return RedirectToAction("Index", "Course");
            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var course = _courseService.Get(id);
            _courseService.Remove(course);
            return RedirectToAction("ManageList");
        }

        [HttpGet]
        public ActionResult Edit(int courseId)
        {           
           var course = _courseService.Get(courseId).ToCourseEditViewModel();
            
            return View(course);
        }

        [HttpPost]
        public ActionResult Edit(CourseEditViewModel course)
        {
                _courseService.Update(course.ToCourseEntity());
               return RedirectToAction("ManageList", "Course");

        }

        private CourseBaseListViewModel GetPageCourseList(IEnumerable<CourseBaseViewModel> courses, int page, int pageSize)
        {
            if (courses == null)
                return null;

            var pageCourses = courses.Skip((page - 1)*pageSize).Take(pageSize);

            PageInfo pageInfo = new PageInfo
            {
                PageNumber = page,
                PageSize = pageSize,
                TotalItems = courses.Count()
            };

            return new CourseBaseListViewModel
            {
                Courses = pageCourses,
                PageInfo = pageInfo
            };
        }

        private EnrolmentInfo GetCourseEnrolmentInfo(int userId, int courseId)
        {

            var enrolment = _enrolmentService.GetEnrolment(userId, courseId);
            EnrolmentInfo enrolmentInfo = new EnrolmentInfo();

            if (enrolment != null)
            {
                enrolmentInfo.IsCompleted = enrolment.CourseCompleted;
                enrolmentInfo.UserEnrolled = true;
                enrolmentInfo.Id = enrolment.Id;
            }
            else
            {
                enrolmentInfo.UserEnrolled = false;
            }

            return enrolmentInfo;
        }

        private EnrolmentInfo GetModuleEnrolmentInfo(int enrolmentId, int moduleId)
        {
            var progress = _enrolmentService.GetModuleProgress(enrolmentId, moduleId);
            EnrolmentInfo enrolmentInfo = new EnrolmentInfo();
            if (progress != null)
            {

                enrolmentInfo.UserEnrolled = true;
                enrolmentInfo.IsCompleted = progress.LessonCompleted && progress.QuizCompleted;
            }
            else
            {
                enrolmentInfo.IsCompleted = false;
                enrolmentInfo.UserEnrolled = false;
            }

            return enrolmentInfo;
        }

    }

}