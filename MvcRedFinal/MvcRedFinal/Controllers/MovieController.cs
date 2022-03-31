using Microsoft.AspNet.Identity;
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

        private MovieService CreateMovieService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MovieService(userId);
            return service;
        }
    }
}