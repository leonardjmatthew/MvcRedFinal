using MvcRedFinal.Model;
using MvcRedFinal.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcRedFinal.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
        public ActionResult Index()
        {
            return View(new ManagerService().GetManagerList());
        }

        public ActionResult Create()
        {
            ViewBag.Title = "New Manager";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ManagerCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (new ManagerService().CreateManager(model))
            {
                TempData["SaveResult"] = "Manager established";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Something went wrong");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var manager = new ManagerService().GetManagerDetailsById(id);
            return View(manager);
        }

        public ActionResult Edit(int id)
        {
            var manager = new ManagerService().GetManagerDetailsById(id);
            return View(new ManagerEdit
            {
                ManagerId = manager.ManagerId,
                Name = manager.Name,


            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ManagerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ManagerId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return View(model);
            }

            if (new ManagerService().UpdateManager(model))
            {
                TempData["SaveResult"] = "Manager updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Something went wrong");
            return View(model);
        }
    }
}