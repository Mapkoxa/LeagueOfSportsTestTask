using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LeagueOfSportsTestTask.Contexts;
using LeagueOfSportsTestTask.Models;

namespace LeagueOfSportsTestTask.Controllers
{
    public class FilmTypesController : Controller
    {
        private readonly ProjectContext db = new ProjectContext();

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] FilmType filmType)
        {
            if (ModelState.IsValid)
            {
                db.FilmTypes.Add(filmType);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            return View(filmType);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
