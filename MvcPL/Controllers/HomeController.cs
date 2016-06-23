using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interfaces.Services;

namespace MvcPL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        public HomeController(IUserService userService)
        {
            // Temporary check
            _userService = userService;

        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.Id = Session["userId"];
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}