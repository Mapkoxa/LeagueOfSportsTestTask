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
    public class FilmsController : Controller
    {
        private ProjectContext db = new ProjectContext();
        
        public ActionResult Index(int page = 1)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index","Home");
            }

            int idUser = ((User) Session["user"]).Id;
            int pageSize = 5;
            List<Film> films = db.Films
                .Where(a=>a.IdUser==idUser)
                .OrderBy(a => a.Id)
                .Skip((page - 1) * pageSize)
                .Include("FilmType")
                .Take(pageSize).ToList();
            films.ForEach(a => a.Description = a.Description.Length >= 50 ? a.Description.Remove(50) + "..." : a.Description);
            PagerInfo pageInfo = new PagerInfo { PageNumber = page, PageSize = pageSize, TotalItems = db.Films.Count() };
            PaginationModel<Film> ivm = new PaginationModel<Film> { PagerInfo = pageInfo, Objects = films };
            return View(ivm);
        }
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Films.Include("FilmType").FirstOrDefault(a=>a.Id==id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }
        
        public ActionResult Create()
        {
            if (Session["user"] == null) return RedirectToAction("Index", "Home");
            SelectList filmTypes = new SelectList(db.FilmTypes, "id", "Name");
            ViewBag.FilmTypes = filmTypes;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdFilmType,Title,Description,Creator,CreatedYear")] Film film)
        {
            film.IdUser = ((User) Session["user"]).Id;
            if (ModelState.IsValid)
            {
                db.Films.Add(film);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            SelectList filmTypes = new SelectList(db.FilmTypes, "id", "Name");
            ViewBag.FilmTypes = filmTypes;
            return View(film);
        }
        
        public ActionResult Edit(int? id)
        {
            if (Session["user"] == null) return RedirectToAction("Index", "Home");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int idUser = ((User)Session["user"]).Id;
            Film film = db.Films.FirstOrDefault(a => a.IdUser==idUser && a.Id==id);
            if (film == null)
            {
                return HttpNotFound();
            }
            SelectList filmTypes = new SelectList(db.FilmTypes, "id", "Name");
            ViewBag.FilmTypes = filmTypes;
            return View(film);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdUser,IdFilmType,Title,Description,Creator,CreatedYear")] Film film)
        {
            if (ModelState.IsValid)
            {
                db.Entry(film).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            SelectList filmTypes = new SelectList(db.FilmTypes, "id", "Name");
            ViewBag.FilmTypes = filmTypes;
            return View(film);
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
