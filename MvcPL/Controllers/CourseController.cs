using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        }

        // GET: Course

        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult List()
        {
            ViewBag.Title = "Courses";
            ViewBag.Id = _userService.GetUserEntity(User.Identity.Name).Id;
            var courses = _courseService.GetaAll().Select(c => c.ToCourseBaseViewModel()).ToList();
            //int userId = _userService.GetUserEntity(User.Identity.Name).Id;
            //var courses = _storageService.GetCreatedCourses(userId).Select(c => c.ToCourseBaseViewModel()).ToList();
            return View(courses);
        }
        [Authorize(Roles = "Manager")]
        public ActionResult ManageList(int storageId)
        {
            var courses = _courseService.GetCreatedCourses(storageId).Select(c =>
            {
                var course = c.ToCourseBaseViewModel();
                course.IsEditable = true;
                return course;
            }).ToList();
            return View("List", courses);
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
            var fullCourse = new CourseFullViewModel(course, modules);
            return View(fullCourse);
        }

        [ChildActionOnly]
        public ActionResult SetCourseBlock(CourseBaseViewModel course)
        {
            
            if (User.IsInRole("Manager"))
            {
                int userId = _userService.GetUserEntity(User.Identity.Name).Id;
                if (course.UserStorageId == userId && !course.Published)
                {
                    course.IsEditable = true;
                }
            }

            return View("_CourseBase", course);
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

        

        //[Authorize(Roles = "Manager")]
        //public ActionResult Manage()
        //{
        //}

        //[Authorize]
        //public ActionResult Catalog()
        //{
        //    var name = User.Identity.Name;
        //    CatalogViewModel model = new CatalogViewModel
        //    {
                
        //    };

        //    return View();
        //}
        //public ActionResult Edit(int courseid)
        //{
        //    try
        //    {

        //    }
        //    catch
        //    {

        //        return View();
        //    }
        //}
    }
}