using Microsoft.AspNet.Identity;
using MvcRedFinal.Data;
using MvcRedFinal.Model;
using MvcRedFinal.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcRedFinal.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            return View(CreateMovieService().GetMovieList());
        }

        public ActionResult Create()
        {
            ViewBag.Title = "New Movie";

            List<Manager> managers = (new ManagerService()).GetManagers().ToList();
            var query = from m in managers
                        select new SelectListItem()
                        {
                            Value = m.Id.ToString(),
                            Text = m.Name,
                        };
            ViewBag.ManagerId = query.ToList();

            return View();

            
        }

       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (CreateMovieService().CreateMovie(model))
            {
                TempData["SaveResult"] = "Movie established";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Something went wrong");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var movie = CreateMovieService().GetMovieDetailsById(id);
            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            var movie = CreateMovieService().GetMovieDetailsById(id);

            List<Manager> Managers = (new ManagerService()).GetManagers().ToList();
            ViewBag.ManagerId = Managers.Select(m => new SelectListItem()
            {
                Value = m.Id.ToString(),
                Text = m.Name,
                Selected = movie.ManagerId == m.Id
            });

            return View(new MovieEdit
            {
                MovieId = movie.MovieId,
                Description = movie.Description,
                ManagerId = movie.ManagerId,
                TheaterId = movie.TheaterId


            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MovieEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.MovieId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return View(model);
            }

            if (CreateMovieService().UpdateMovie(model))
            {
                TempData["SaveResult"] = "Meeting updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Something went wrong");
            return View(model);
        }

        private MovieService CreateMovieService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MovieService(userId);
            return service;
        }
    }
}