using BitcoinBeach.Models;
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
            var model = new UnitListItem[0];
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}