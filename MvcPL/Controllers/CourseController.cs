using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models;
using MvcPL.Models.Course;

namespace MvcPL.Controllers
{
    public class CourseController : Controller
    {
        private readonly IStorageService _storageService;
        private readonly IUserService _userService;
        private readonly IModuleService _moduleService;
        public CourseController(IStorageService storageService, IUserService userService, IModuleService moduleService)
        {
            _storageService = storageService;
            _userService = userService;
            _moduleService = moduleService;
        }
        // GET: Course
        [Authorize]
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult List()
        {
            ViewBag.Title = "Courses";
            //int userId = _userService.GetUserEntity(User.Identity.Name).Id;
            //var courses = _storageService.GetCreatedCourses(userId).Select(c => c.ToCourseBaseViewModel()).ToList();
            return View();
        }
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Content(int courseId)
        {
            var modules = _moduleService.GetCourseModules(courseId).Select(m => m.ToModuleBaseViewModel()).ToList();
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(CourseCreateViewModel courseModel)
        {
            if (ModelState.IsValid)
            {
                int userId = _userService.GetUserEntity(User.Identity.Name).Id;
                //_storageService.AddCourse(userId, courseModel.ToCourseEntity());
                return RedirectToAction("Index", "Course");
            }
            return View(courseModel);
        }

        //[Authorize]
        //public ActionResult Catalog()
        //{
        //    var name = User.Identity.Name;
        //    CatalogViewModel model = new CatalogViewModel
        //    {
                
        //    };

        //    return View();
        //}
    }
}