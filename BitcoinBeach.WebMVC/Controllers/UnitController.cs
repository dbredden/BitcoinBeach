﻿using BitcoinBeach.Models;
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
    public class UnitController : Controller
    {
        // GET: Unit
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new UnitService(userId);
            var model = service.GetUnits();

            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (UnitCreate model)
        {
            if (!ModelState.IsValid) return View(model);
           
            var service = CreateUnitService();

            if (service.CreateUnit(model))
            {
                TempData["SaveResult"] = "Your unit was successfully created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your unit could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateUnitService();
            var model = svc.GetUnitById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateUnitService();
            var detail = service.GetUnitById(id);
            var model =
                new UnitEdit
                {
                    Title = detail.Title,
                    Description = detail.Description,
                    Address = detail.Address,
                    Price = detail.Price,
                    Guests = detail.Guests,
                    Beds = detail.Beds,
                    Bathrooms = detail.Bathrooms
                };
            return View(model);
        }

        private UnitService CreateUnitService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new UnitService(userId);
            return service;
        }
    }
}