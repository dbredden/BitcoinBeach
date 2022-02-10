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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            UnitService service = CreateUnitService();

            service.CreateUnit(model);

            return RedirectToAction("Index");
        }

        private UnitService CreateUnitService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new UnitService(userId);
            return service;
        }
    }
}