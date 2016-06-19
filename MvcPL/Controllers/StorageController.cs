using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces.Services;

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
        public ActionResult Index()
        {
            ViewBag.Id = _userService.GetUserEntity(User.Identity.Name).Id;
            return View();
        }
    }
}