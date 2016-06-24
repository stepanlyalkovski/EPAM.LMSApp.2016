using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces.Entities.Courses.Content;
using BLL.Interfaces.Services;
using MvcPL.Infrastructure;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models;
using MvcPL.Models.LessonModels;

namespace MvcPL.Controllers
{
    [Authorize]
    public class LessonPageController : Controller
    {
        private readonly ILessonPageService _lessonPage;
        private readonly IUserService _userService;
        private readonly IStorageService _storageService;

        public LessonPageController(ILessonPageService lessonPage, IUserService userService, IStorageService storageService)
        {
            _lessonPage = lessonPage;
            _userService = userService;
            _storageService = storageService;
        }

        // GET: LessonPage
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(LessonPageEditModel page, int pageNumber, HttpPostedFileBase upload)
        {
            var resultPage = page.ToLessonPageEntity();

            if (upload != null)
            {
                var storageId = _userService.GetUserEntity(User.Identity.Name).Id;

                    string path = Server.MapPath($"~/App_Data/Storages/User{storageId}/");
                    string fileName = FileStorageHepler.SaveFileToDisk(upload, path);
                    string virtualPath = $"~/App_Data/Storages/User{storageId}/" + fileName;

                    ImageEntity image = new ImageEntity
                    {
                        Path = virtualPath,
                        StorageId = storageId,
                        Title = page.Image.Title
                    };
                    _storageService.AddImage(image);
                    var currentImage = _storageService.GetImage(image.Path);
                    resultPage.ImageId = currentImage.Id;
                               
            }

            _lessonPage.Update(resultPage);
            return RedirectToAction("ContentEdit", "Lesson", new {lessonId = page.LessonId, page = pageNumber});
        }
    }
}