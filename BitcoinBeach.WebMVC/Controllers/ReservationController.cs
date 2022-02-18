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

        private ReservationService CreateReservationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReservationService(userId);
            return service;
        }
    }
}