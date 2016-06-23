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
    public class LessonPageController : Controller
    {
        private readonly ILessonPageService _lessonPage;

        public LessonPageController(ILessonPageService lessonPage)
        {
            _lessonPage = lessonPage;
        }

        // GET: LessonPage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(LessonPageEditModel page)
        {
            //if (page == null)
            //    throw new NullReferenceException();
            //_lessonPage.Add(page.ToLessonPageEntity());
            //if (Request.IsAjaxRequest())
            //{
            //    //return PartialView("_LessonPageEdit", )
            //}
            throw new NotImplementedException();
        }
    }
}