using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models;
using MvcPL.Models.ModuleModels;
using WebGrease.Css.Extensions;

namespace MvcPL.Controllers
{
    [Authorize]
    public class ModuleController : Controller
    {
        private readonly IModuleService _moduleService;
        private readonly ILessonService _lessonService;
        private readonly IStorageService _storageService;
        private readonly ICourseService _courseService;
        private readonly IUserService _userService;
        private readonly IEnrolmentService _enrolmentService;

        public ModuleController(IModuleService moduleService, ILessonService lessonService, IStorageService storageService, ICourseService courseService, IUserService userService, IEnrolmentService enrolmentService)
        {
            _moduleService = moduleService;
            _lessonService = lessonService;
            _storageService = storageService;
            _courseService = courseService;
            _userService = userService;
            _enrolmentService = enrolmentService;
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
            var enrolment = _enrolmentService.GetEnrolment(userId, courseId);            
            bool editMode = course.UserStorageId == userId;

            if (enrolment != null)
            {
                var progress = _enrolmentService.GetModuleProgress(enrolment.Id, moduleId);

                if (lesson != null)
                {
                    lesson.EnrolmentInfo = new EnrolmentInfo
                    {
                        IsCompleted = progress.LessonCompleted,
                        UserEnrolled = true,
                        Id = enrolment.Id                        
                    };
                }

                if (quiz != null)
                {
                    quiz.EnrolmentInfo = new EnrolmentInfo
                    {
                        IsCompleted = progress.QuizCompleted,
                        UserEnrolled = true,
                        Id = enrolment.Id
                    };
                }

            }

            if (module != null)
            {
                //Session["CurrentModuleId"] = module.Id;
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
        public ActionResult Edit(int id, int courseId)
        {
            var module = _moduleService.Get(id).ToModuleBaseViewModel();
            module.CourseId = courseId;
            return View(module);
        }

        // POST: Module/Edit/5
        [HttpPost]
        public ActionResult Edit(ModuleBaseViewModel module)
        {
            try
            {
                _moduleService.Update(module.ToModuleEntity());
                return RedirectToAction("Content","Course", new {courseId = module.CourseId});
            }
            catch
            {
                return View();
            }
        }

    }
}
