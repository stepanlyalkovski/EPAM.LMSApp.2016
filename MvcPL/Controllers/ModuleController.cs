using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models.ModuleModels;
using WebGrease.Css.Extensions;

namespace MvcPL.Controllers
{
    public class ModuleController : Controller
    {
        private readonly IModuleService _moduleService;
        private readonly ILessonService _lessonService;
        private readonly IStorageService _storageService;
        private readonly ICourseService _courseService;
        private readonly IUserService _userService;

        public ModuleController(IModuleService moduleService, ILessonService lessonService, IStorageService storageService, ICourseService courseService, IUserService userService)
        {
            _moduleService = moduleService;
            _lessonService = lessonService;
            _storageService = storageService;
            _courseService = courseService;
            _userService = userService;
        }

        // GET: Module
        public ActionResult Index()
        {
            return View();
        }

        // GET: Module/Details/5
        public ActionResult Details(int moduleId, int courseId)
        {
            var quiz = _moduleService.GetModuleQuiz(moduleId).ToQuizBaseViewModel();
            var lesson = _moduleService.GetModuleLesson(moduleId)?.ToLessonBaseViewModel();
            var articles = _moduleService.GetModuleArticles(moduleId)?.Select(a => a.ToArticleBaseViewModel());
            var module = _moduleService.Get(moduleId)?.ToModuleBaseViewModel();
             int userId = _userService.GetUserEntity(User.Identity.Name).Id;
            var course = _courseService.Get(courseId);

            bool editMode = course.UserStorageId == userId;

            if (module != null)
            {

                Session["CurrentModuleId"] = module.Id;

                var fullModule = new ModuleContentViewModel
                {
                    Articles = articles,
                    Lesson = lesson,
                    Quiz = quiz,
                    BaseInfo = module
                };
                fullModule.BaseInfo.CourseId = courseId;
                    if (editMode)
                    {
                        fullModule.BaseInfo.IsEditable = true;
                    }

                    if(fullModule.Lesson != null)
                        fullModule.Lesson.ModuleId = module.Id;
                   
                return View(fullModule);
            }
            return View("Error");

        }

        // GET: Module/Edit/5
        public ActionResult Edit(int id)
        {
            var module = _moduleService.Get(id).ToModuleBaseViewModel();

            return View(module);
        }

        // POST: Module/Edit/5
        [HttpPost]
        public ActionResult Edit(ModuleBaseViewModel module)
        {
            try
            {
                _moduleService.Update(module.ToModuleEntity());
                return RedirectToAction("ManageList","Course");
            }
            catch
            {
                return View();
            }
        }

    }
}
