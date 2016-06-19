using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Services;
using Microsoft.Ajax.Utilities;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models.ProfileModels;

namespace MvcPL.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;
        private readonly IUserService _userService;
        public ProfileController(IProfileService profileService, IUserService userService)
        {
            _profileService = profileService;
            _userService = userService;
        }
        // GET: Profile
        public ActionResult Index()
        {
            ViewBag.Id = _userService.GetUserEntity(User.Identity.Name).Id;

            return View();
        }

        // GET: Profile/Details/5
        public ActionResult Details(int id)
        {
            var profile = _profileService.Get(id);

            return View(profile.ToProfileViewModel());
        }

        // GET: Profile/Edit/5
        public ActionResult Edit(int id)
        {
            var profile = _profileService.Get(id);
            return View(profile.ToProfileViewModel());
        }

        // POST: Profile/Edit/5
        [HttpPost]
        public ActionResult Edit(ProfileViewModule profile)
        {
            try
            {
               
                _profileService.Update(profile.ToProfileViewModel());              
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        // POST: Profile/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
