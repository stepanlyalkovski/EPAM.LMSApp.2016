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
        private readonly IEnrolmentService _enrolmentService;
        private readonly ILessonPageService _lessonPageService;
        private readonly IModuleService _moduleService;

        public LessonController(ILessonService lessonService, IStorageService storageService, IUserService userService, IEnrolmentService enrolmentService, ILessonPageService lessonPageService, IModuleService moduleService)
        {
            _lessonService = lessonService;
            _storageService = storageService;
            _userService = userService;
            _enrolmentService = enrolmentService;
            _lessonPageService = lessonPageService;
            _moduleService = moduleService;
        }

        // GET: Lesson
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create(int moduleId, int courseId)
        {
            var lesson = new LessonBaseViewModel {ModuleId = moduleId, CourseId = courseId};
            return View(lesson);
        }

        public ActionResult Edit(int courseId, int moduleId, int lessonId)
        {
            var lesson = _lessonService.GetLesson(lessonId).ToLessonBaseEditModel();
            lesson.ModuleId = moduleId;
            lesson.CourseId = courseId;
            return View(lesson);
        }

        [HttpPost]
        public ActionResult Edit(LessonBaseEditModel lesson)
        {
            _lessonService.Update(lesson.ToLessonEntity());
            return RedirectToAction("Details", "Module", new {moduleId = lesson.ModuleId, courseId = lesson.CourseId});
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
            return RedirectToAction("ContentEdit", "Lesson", new
                        {
                            lessonId,
                            moduleId = lesson.ModuleId,
                            courseId = lesson.CourseId
                        });
        }

        [HttpGet]
        public ActionResult Delete(int courseId, int moduleId, int lessonId)
        {
            var lesson = _lessonService.GetLesson(lessonId).ToLessonBaseViewModel();
            lesson.ModuleId = moduleId;
            lesson.CourseId = courseId;

            return View(lesson);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(LessonBaseViewModel lesson)
        {
            var lessonEntity = _lessonService.GetLesson(lesson.Id);
            if (lessonEntity != null)
            {
                var module = _moduleService.Get(lesson.ModuleId);
                module.LessonId = null;
                _moduleService.Update(module);
                _lessonService.RemoveLesson(lessonEntity);
            }
            return RedirectToAction("Details", "Module", new { moduleId = lesson.ModuleId, courseId = lesson.CourseId});
        }

        public ActionResult ContentEdit(int lessonId, int moduleId, int courseId, int page = 1)
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

            viewLesson.BaseInfo.CourseId = courseId;
            viewLesson.BaseInfo.ModuleId = moduleId;

            if (Request.IsAjaxRequest())
            {
                return PartialView("_LessonPageEdit", viewLesson);
            }
            return View(viewLesson);
        }

        public ActionResult Complete(int lessonId, int moduleId, int courseId, int enrolmentId)
        {
            _enrolmentService.ChangeLessonProgress(enrolmentId, moduleId, true);
            return RedirectToAction("Details", "Module", new
                    {
                        moduleId,
                        courseId,
                    });
        }

        public ActionResult Content(int lessonId, int moduleId, int courseId, int page = 1)
        {
            var lesson = _lessonService.GetLesson(lessonId);
            var fullPages = _lessonPageService.GetFullPages(lessonId).ToList();
            var user = _userService.GetUserEntity(User.Identity.Name);
            int pagesCount = fullPages.Count();
            var enrolment = _enrolmentService.GetEnrolment(user.Id, courseId);
            var progress = _enrolmentService.GetModuleProgress(enrolment.Id, moduleId);
            _enrolmentService.GetModuleProgress(enrolment.Id, moduleId);

            var currentPage = fullPages.Skip((page - 1)).First();

            var image = currentPage.Image;
            if (image != null)
            {
                image.Path = Server.MapPath(image.Path);
            }

            PageInfo pageInfo = new PageInfo
            {
                PageSize = 1,
                PageNumber = page,
                TotalItems = pagesCount
            };
            var viewLesson = new LessonContentViewModel
            {
                BaseInfo = lesson.ToLessonBaseViewModel(),
                PageInfo = pageInfo,
                Page = currentPage.Pages.ToLessonPageEditModel(),
                EnrolmentInfo =  new EnrolmentInfo { Id = enrolment.Id, IsCompleted = progress.LessonCompleted}
            };
            viewLesson.Page.Image = image.ToImageViewModel();

            viewLesson.BaseInfo.CourseId = courseId;
            viewLesson.BaseInfo.ModuleId = moduleId;

            if (Request.IsAjaxRequest())
            {
                return PartialView("_LessonPage", viewLesson);
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