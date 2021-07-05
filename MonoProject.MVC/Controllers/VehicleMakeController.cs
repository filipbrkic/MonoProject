using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonoProject.MVC.Controllers
{
    public class VehicleMakeController : Controller
    {
        // GET: VehicleMakeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: VehicleMakeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VehicleMakeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleMakeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleMakeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VehicleMakeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleMakeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VehicleMakeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
