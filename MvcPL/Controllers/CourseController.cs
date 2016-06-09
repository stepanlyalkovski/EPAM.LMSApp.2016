using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPL.Models;

namespace MvcPL.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.Title = "Courses";
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        //[Authorize]
        //public ActionResult Catalog()
        //{
        //    var name = User.Identity.Name;
        //    CatalogViewModel model = new CatalogViewModel
        //    {
                
        //    };

        //    return View();
        //}
    }
}