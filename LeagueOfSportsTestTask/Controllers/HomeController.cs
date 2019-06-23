using LeagueOfSportsTestTask.Contexts;
using LeagueOfSportsTestTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeagueOfSportsTestTask.Controllers
{
    public class HomeController : Controller
    {
        // GET: Films
        public ActionResult Index(int page = 1)
        {
            using (var db = new ProjectContext())
            {
                int pageSize = 20; // количество объектов на страницу
                List<Film> films = db.Films.Include("FilmType").OrderBy(a=>a.Id).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                films.ForEach(a => a.Description = a.Description.Length >= 50 ? a.Description.Remove(50) + "..." : a.Description);
                PagerInfo pageInfo = new PagerInfo { PageNumber = page, PageSize = pageSize, TotalItems = db.Films.Count() };
                PaginationModel<Film> ivm = new PaginationModel<Film> { PagerInfo = pageInfo, Objects = films };
                return View(ivm);
            }
        }

    }
}