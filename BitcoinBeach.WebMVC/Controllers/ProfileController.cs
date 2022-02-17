using BitcoinBeach.Models;
using BitcoinBeach.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitcoinBeach.WebMVC.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProfileService(userId);
            var model = service.GetProfiles();

            return View(model);
        }
        // GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProfileCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateProfileService();

            if (service.CreateProfile(model))
            {
                TempData["SaveResult"] = "New profile was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "New profile could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateProfileService();
            var model = svc.GetProfileById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateProfileService();
            var detail = service.GetProfileById(id);
            var model =
                new ProfileEdit
                {
                    ProfileId = detail.ProfileId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    Email = detail.Email,
                    PhoneNumber = detail.PhoneNumber
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProfileEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.ProfileId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateProfileService();

            if (service.UpdateProfile(model))
            {
                TempData["SaveResult"] = "The Profile was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your profile could not be updated.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateProfileService();
            var model = svc.GetProfileById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProfile(int id)
        {
            var service = CreateProfileService();

            service.DeleteProfile(id);

            TempData["SaveResult"] = "The account was deleted";

            return RedirectToAction("Index");
        }

        private ProfileService CreateProfileService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProfileService(userId);
            return service;
        }
    }
}