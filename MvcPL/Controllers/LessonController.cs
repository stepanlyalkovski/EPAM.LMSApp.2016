using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models.LessonModels;

namespace MvcPL.Controllers
{
    [Authorize]
    public class LessonController : Controller
    {
        private readonly ILessonService _lessonService;
        private readonly ILessonPageService _lessonPageService;

        public LessonController(ILessonService lessonService, ILessonPageService lessonPageService)
        {
            _lessonService = lessonService;
            _lessonPageService = lessonPageService;
        }

        // GET: Lesson
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create(int moduleId)
        {
            var lesson = new LessonBaseViewModel {ModuleId = moduleId};
            return View(lesson);
        }

        [HttpPost]
        public ActionResult Create(LessonBaseViewModel lesson)
        {
            try
            {
                _lessonService.AddLesson(lesson.ToLessonEntity());
            }
            catch
            {

                return View();
            }
            var lessonId = _lessonService.GetModuleLesson(lesson.ModuleId).Id;
            return RedirectToAction("ContentEdit", "Lesson", new {lessonId});
        }

        public ActionResult ContentEdit(int lessonId)
        {
            var dbLesson = _lessonService.GetLesson(lessonId);
            var dbPages = _lessonPageService.GetLessonPages(lessonId);
            var viewLesson = new LessonContentViewModel
            {
                BaseInfo = dbLesson.ToLessonBaseViewModel(),
                Pages = new List<LessonPageEditModel>(dbPages.Select(p => p.ToLessonPageEditModel()))
            };
            return View(viewLesson);
        }

        [HttpPost]
        public ActionResult ContentEdit(LessonContentViewModel lesson)
        {


            return View();
        }
    }
}