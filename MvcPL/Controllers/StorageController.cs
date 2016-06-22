using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces.Entities.Courses.Content;
using BLL.Interfaces.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models;

namespace MvcPL.Controllers
{
    [Authorize(Roles = "Manager")]
    public class StorageController : Controller
    {
        private readonly IStorageService _storageService;
        private readonly IUserService _userService;

        public StorageController(IStorageService storageService, IUserService userService)
        {
            _storageService = storageService;
            _userService = userService;
        }

        // GET: Storage
        public ActionResult Content()
        {
            ViewBag.Id = _userService.GetUserEntity(User.Identity.Name).Id;

            return View("Index");
        }

        public ActionResult ImageCatalog()
        {
            int storageId = _userService.GetUserEntity(User.Identity.Name).Id;
            ViewBag.StorageId = storageId;
            var images = _storageService.GetImages(storageId).Select(im => im.ToImageViewModel()).ToList();
            foreach (var image in images)
            {
                image.Path = Server.MapPath(image.Path);
            }
            return View(images);
        }

        public ActionResult Create(ImageViewModel image)
        {

            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult Upload(string title, HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                
                var storageId = _userService.GetUserEntity(User.Identity.Name).Id;
                string path = Server.MapPath($"~/App_Data/Storages/User{storageId}/");           
                Directory.CreateDirectory(path);
                string virtualPath = $"~/App_Data/Storages/User{storageId}/" + fileName;               
                upload.SaveAs(Server.MapPath(virtualPath));
                ImageEntity image = new ImageEntity { Path = virtualPath };
                image.StorageId = storageId;
                image.Title = title;
                _storageService.AddImage(image);
            }
            return RedirectToAction("ImageCatalog");
        }

        public FileResult GetImage(int id)
        {
            var image = _storageService.GetImage(id).ToImageViewModel();
            return new FilePathResult(Server.MapPath(image.Path),"image/*");
        }


    }
}