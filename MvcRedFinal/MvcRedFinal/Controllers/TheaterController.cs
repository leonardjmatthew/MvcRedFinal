using MvcRedFinal.Model;
using MvcRedFinal.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcRedFinal.Controllers
{
    public class TheaterController : Controller
    {
        // GET: Theater
        public ActionResult Index()
        {
            return View(new TheaterService().GetTheaterList());
        }

        public ActionResult Create()
        {
            ViewBag.Title = "New Theater";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TheaterCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (new TheaterService().CreateTheater(model))
            {
                TempData["SaveResult"] = "Theater established";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Something went wrong");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var theater = new TheaterService().GetTheaterDetailsById(id);
            return View(theater);
        }

        public ActionResult Edit(int id)
        {
            var theater = new TheaterService().GetTheaterDetailsById(id);
            return View(new TheaterEdit
            {
                TheaterId = theater.TheaterId,
                Name = theater.Name,


            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TheaterEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TheaterId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return View(model);
            }

            if (new TheaterService().UpdateTheater(model))
            {
                TempData["SaveResult"] = "Theater updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Something went wrong");
            return View(model);
        }

    }
}
