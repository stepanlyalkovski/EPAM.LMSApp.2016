using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces.Services;
using MvcPL.Infrastructure.Mappers;

namespace MvcPL.Controllers
{
    public class EnrolmentController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IModuleService _moduleService;
        private readonly ILessonService _lessonService;
        private readonly IEnrolmentService _enrolmentService;
        private readonly IUserService _userService;

        public EnrolmentController(ICourseService courseService, IModuleService moduleService, ILessonService lessonService, IEnrolmentService enrolmentService, IUserService userService)
        {
            _courseService = courseService;
            _moduleService = moduleService;
            _lessonService = lessonService;
            _enrolmentService = enrolmentService;
            _userService = userService;
        }

        // GET: Enrolment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register(int courseId)
        {
            var course = _courseService.Get(courseId).ToCourseBaseViewModel();
            return View(course);
        }

        [HttpPost, ActionName("Register")]
        [ValidateAntiForgeryToken]
        public ActionResult CofirmRegister(int courseId)
        {
            int userId = _userService.GetUserEntity(User.Identity.Name).Id;
            _enrolmentService.AttendCourse(userId, courseId);

            return RedirectToAction("Content","Course", new {courseId});
        }

        public ActionResult Delete(int courseId)
        {
            var course = _courseService.Get(courseId).ToCourseBaseViewModel();
            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int courseId)
        {
            int userId = _userService.GetUserEntity(User.Identity.Name).Id;
            var enrolment = _enrolmentService.GetEnrolment(userId, courseId);
            _enrolmentService.Remove(enrolment);
            return RedirectToAction("Index", "Course");
        }

    }
}