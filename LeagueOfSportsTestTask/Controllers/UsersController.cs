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
    public class UsersController : Controller
    {
        private readonly ProjectContext _db = new ProjectContext();


        public JsonResult IsUserExists(string Login, int? Id)
        {
            var validateName = _db.Users.FirstOrDefault(x => x.Login == Login && x.Id != Id);
            if (validateName != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Register()
        {
            if (Session["user"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Login()
        {
            if (Session["user"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Login,Password")] User user)
        {
            if (Session["user"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            var registerUser = _db.Users.FirstOrDefault(a => a.Login == user.Login && a.Password == user.Password);
            if (registerUser != null)
            {
                Session["user"] = registerUser;
                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Login,Password")] User user)
        {
            if (Session["user"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                _db.Users.Add(user);
                _db.SaveChanges();
                Session["user"] = user;
                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
