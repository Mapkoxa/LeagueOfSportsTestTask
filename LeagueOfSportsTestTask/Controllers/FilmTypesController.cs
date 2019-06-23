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
        private ProjectContext db = new ProjectContext();

        // GET: FilmTypes
        public ActionResult Index()
        {
            return View(db.FilmTypes.ToList());
        }

        // GET: FilmTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FilmType filmType = db.FilmTypes.Find(id);
            if (filmType == null)
            {
                return HttpNotFound();
            }
            return View(filmType);
        }

        // GET: FilmTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FilmTypes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] FilmType filmType)
        {
            if (ModelState.IsValid)
            {
                db.FilmTypes.Add(filmType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(filmType);
        }

        // GET: FilmTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FilmType filmType = db.FilmTypes.Find(id);
            if (filmType == null)
            {
                return HttpNotFound();
            }
            return View(filmType);
        }

        // POST: FilmTypes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] FilmType filmType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filmType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(filmType);
        }

        // GET: FilmTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FilmType filmType = db.FilmTypes.Find(id);
            if (filmType == null)
            {
                return HttpNotFound();
            }
            return View(filmType);
        }

        // POST: FilmTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FilmType filmType = db.FilmTypes.Find(id);
            db.FilmTypes.Remove(filmType);
            db.SaveChanges();
            return RedirectToAction("Index");
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
