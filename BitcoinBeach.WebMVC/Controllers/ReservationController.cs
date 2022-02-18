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
    public class ReservationController : Controller
    {
        // GET: Reservation
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReservationService(userId);
            var model = service.GetReservations();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReservationCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateReservationService();

            if (service.CreateReservation(model))
            {
                TempData["SaveResult"] = "The reservation was created.";
                return RedirectToAction("Index");
            };

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateReservationService();
            var model = svc.GetReservationById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateReservationService();
            var detail = service.GetReservationById(id);
            var model =
                new ReservationEdit
                {
                    ReservationId = detail.ReservationId,
                    ProfileId = detail.ProfileId,
                    UnitId = detail.UnitId,
                    ReservationStartDate = detail.ReservationStartDate,
                    ReservationEndDate = detail.ReservationEndDate
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ReservationEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.ReservationId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateReservationService();

            if (service.UpdateReservation(model))
            {
                TempData["SaveResult"] = "The reservation was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The reservation could not be updated.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateReservationService();
            var model = svc.GetReservationById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteReservation(int id)
        {
            var service = CreateReservationService();

            service.DeleteReservation(id);

            TempData["SaveResult"] = "The reservation was deleted";

            return RedirectToAction("Index");
        }


        private ReservationService CreateReservationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReservationService(userId);
            return service;
        }
    }
}