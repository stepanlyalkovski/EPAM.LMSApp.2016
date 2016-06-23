using System;
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

        public CourseController(IStorageService storageService, ICourseService courseService, IUserService userService, IModuleService moduleService)
        {
            _storageService = storageService;
            _courseService = courseService;
            _userService = userService;
            _moduleService = moduleService;
            //Temporary
        }

        // GET: Course

        public ActionResult Index(string searchBy, string searchField, string tags, int page = 1)
        {
            ViewBag.Title = "Courses";
            ViewBag.Id = _userService.GetUserEntity(User.Identity.Name).Id;
            IEnumerable<CourseBaseViewModel> courses;
            int pageSize = 5;
            //TODO searchBy
            if (String.IsNullOrEmpty(searchField) && String.IsNullOrEmpty(tags))
            {
                int courseNumber = 10;

                courses = _courseService.GetRandom(courseNumber).Select(c => c.ToCourseBaseViewModel()).ToList();
            }
            else
            {
                courses = _courseService.Search(searchField, tags.Split()).Select(c => c.ToCourseBaseViewModel()).ToList();
            }

            var courseList = GetPageCourseList(courses, page, pageSize);
            courseList.PageUrl = courseList.PageUrl = x => Url.Action("Index", "Course", new { page = x });
            if (Request.IsAjaxRequest())
            {
                return PartialView("_CourseBaseList", courseList);
            }

            return View(courseList);
        }

        //[ChildActionOnly]
        //public ActionResult List(string searchBy, string searchField, string tags)
        //{
        //    ViewBag.Title = "Courses";
        //    int userId = _userService.GetUserEntity(User.Identity.Name).Id;
        //    ViewBag.Id = userId;
        //    IEnumerable<CourseBaseViewModel> courses;
            
        //    //TODO searchBy
        //    if (String.IsNullOrEmpty(searchField) && String.IsNullOrEmpty(tags))
        //    {
        //        int courseNumber = 5;

        //        courses = _courseService.GetRandom(courseNumber).Select(c => c.ToCourseBaseViewModel()).ToList();
        //    }
        //    else
        //    {
        //        courses = _courseService.Search(searchField, tags.Split(',')).Select(c => c.ToCourseBaseViewModel()).ToList();
        //    }

        //    ViewBag.FormData = new {SearchFiled = searchField, SearchBy = searchBy, Tags = tags};
        //    //int userId = _userService.GetUserEntity(User.Identity.Name).Id;
        //    //var courses = _storageService.GetCreatedCourses(userId).Select(c => c.ToCourseBaseViewModel()).ToList();
        //    return View(courses); 
        //}

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
            int userId = (int)Session["userId"];
            foreach (var module in modules)
            {
                module.CourseId = courseId;

                if (userId == course.UserStorageId)
                {
                    module.IsEditable = true;
                }
            }
            var fullCourse = new CourseFullViewModel(course, modules);
            return View(fullCourse);
        }

        //[ChildActionOnly]
        //public ActionResult SetCourseBlock(CourseBaseViewModel course)
        //{
            
        //    if (User.IsInRole("Manager"))
        //    {
        //        int userId = _userService.GetUserEntity(User.Identity.Name).Id;
        //        if (course.UserStorageId == userId && !course.Published)
        //        {
        //            course.IsEditable = true;
        //        }
        //    }

        //    return View("_CourseBase", course);
        //}

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

            var PageCourses = courses.Skip((page - 1)*pageSize).Take(pageSize);

            PageInfo pageInfo = new PageInfo
            {
                PageNumber = page,
                PageSize = pageSize,
                TotalItems = courses.Count()
            };

            return new CourseBaseListViewModel
            {
                Courses = PageCourses,
                PageInfo = pageInfo
            };
        }
    }


}