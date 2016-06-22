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

        public ModuleController(IModuleService moduleService, ILessonService lessonService, IStorageService storageService)
        {
            _moduleService = moduleService;
            _lessonService = lessonService;
            _storageService = storageService;
        }

        // GET: Module
        public ActionResult Index()
        {
            return View();
        }

        // GET: Module/Details/5
        public ActionResult Details(int moduleId)
        {
            var quiz = _moduleService.GetModuleQuiz(moduleId).ToQuizBaseViewModel();
            var lesson = _moduleService.GetModuleLesson(moduleId)?.ToLessonBaseViewModel();
            var articles = _moduleService.GetModuleArticles(moduleId)?.Select(a => a.ToArticleBaseViewModel());
            var module = _moduleService.Get(moduleId)?.ToModuleBaseViewModel();
            var fullModule = new ModuleContentViewModel
            {
                Articles = articles,
                Lesson = lesson,
                Quiz = quiz,
                BaseInfo = module
            };
            return View(fullModule);
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
