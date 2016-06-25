using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using BLL.Interfaces.Entities.Courses.Content;
using BLL.Interfaces.Services;
using MvcPL.Infrastructure;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models;
using MvcPL.Models.LessonModels;

namespace MvcPL.Controllers
{
    [Authorize]
    public class LessonController : Controller
    {
        private readonly ILessonService _lessonService;
        private readonly IStorageService _storageService;
        private readonly IUserService _userService;
        private readonly ILessonPageService _lessonPageService;
        private readonly IModuleService _moduleService;

        public LessonController(ILessonService lessonService, IStorageService storageService, IUserService userService, ILessonPageService lessonPageService, IModuleService moduleService)
        {
            _lessonService = lessonService;
            _storageService = storageService;
            _userService = userService;
            _lessonPageService = lessonPageService;
            _moduleService = moduleService;
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

        public ActionResult Edit(int lessonId, int moduleId)
        {
            var lesson = _lessonService.GetLesson(lessonId).ToLessonBaseEditModel();
            lesson.ModuleId = moduleId;
            return View(lesson);
        }

        [HttpPost]
        public ActionResult Edit(LessonBaseEditModel lesson)
        {
            _lessonService.Update(lesson.ToLessonEntity());
            return RedirectToAction("Details", "Module", new {moduleId = lesson.ModuleId});
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

        [HttpGet]
        public ActionResult Delete(int lessonId, int moduleId)
        {
            var lesson = _lessonService.GetLesson(lessonId).ToLessonBaseViewModel();
            ViewBag.ModuleId = moduleId;
            return View(lesson);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int lessonId, int moduleId)
        {
            var lesson = _lessonService.GetLesson(lessonId);
            if (lesson != null)
            {
                var module = _moduleService.Get(moduleId);
                module.LessonId = null;
                _moduleService.Update(module);
                _lessonService.RemoveLesson(lesson);
            }
            return RedirectToAction("ManageList", "Course"); //TODO redirect to module content
        }

        public ActionResult ContentEdit(int lessonId, int page = 1)
        {
            var lesson = _lessonService.GetLesson(lessonId);
            var fullPages = _lessonPageService.GetFullPages(lessonId).ToList();
            int pagesCount = fullPages.Count();

            var currentPage = fullPages.Skip((page - 1)).First();

            var image = currentPage.Image;
            if (image != null)
            {
                image.Path = Server.MapPath(image.Path);
            }
            
            PageInfo pageInfo= new PageInfo
            {
                PageSize = 1,
                PageNumber = page,
                TotalItems = pagesCount
            };

            var viewLesson = new LessonContentEditViewModel
            {
                BaseInfo = lesson.ToLessonBaseViewModel(),
                PageInfo = pageInfo,
                Page = currentPage.Pages.ToLessonPageEditModel()
            };
            viewLesson.Page.Image = image.ToImageViewModel();
            viewLesson.BaseInfo.ModuleId = (int)Session["CurrentModuleId"];
            if (Request.IsAjaxRequest())
            {
                return PartialView("_LessonPageEdit", viewLesson);
            }
            return View(viewLesson);
        }

        //[HttpPost]
        //public ActionResult ContentEdit(LessonContentEditViewModel lesson, HttpPostedFileBase upload)
        //{
        //    if (upload != null)
        //    {

        //        var storageId = _userService.GetUserEntity(User.Identity.Name).Id;
        //        string path = Server.MapPath($"~/App_Data/Storages/User{storageId}/");
        //        string fileName = FileStorageHepler.SaveFileToDisk(upload, path);
        //        string virtualPath = $"~/App_Data/Storages/User{storageId}/" + fileName;


        //        ImageEntity image = new ImageEntity
        //        {
        //            Path = virtualPath,
        //            StorageId = storageId,
        //            Title = lesson.Page.Image.Title
        //        };
        //        _storageService.AddImage(image);
        //        _lessonPageService.AttachImage(image, );
        //        var resultLesson = lesson.ToLessonEntity();
        //        _lessonService.Update(resultLesson);
        //    }

        //    return View();
        //}

        
    }
}