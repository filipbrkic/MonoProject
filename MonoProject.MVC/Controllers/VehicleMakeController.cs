using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonoProject.Common.Models;
using MonoProject.DAL.Models;
using MonoProject.MVC.Models;
using MonoProject.Service.Common;
using System;
using System.Threading.Tasks;

namespace MonoProject.MVC.Controllers
{
    public class VehicleMakeController : Controller
    {
        private readonly IMapper mapper;
        private readonly IVehicleMakeService vehicleMakeService;

        public VehicleMakeController(IMapper mapper, IVehicleMakeService vehicleMakeService)
        {
            this.mapper = mapper;
            this.vehicleMakeService = vehicleMakeService;
        }

        // GET: VehicleMakeController
        public async Task<ActionResult> Index()
        {
            return View();
        }

        // GET: VehicleMakeController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var result = await vehicleMakeService.GetAsync(id);
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
        public async Task<ActionResult> Create(VehicleMakeViewModel vehicleMakeViewModel)
        {
            try
            {
                await vehicleMakeService.AddAsync(mapper.Map<VehicleMakeDTO>(vehicleMakeViewModel));
                return RedirectToAction(nameof(VehicleMake));
            }
            catch
            {
                return RedirectToAction(nameof(VehicleMake));
            }
        }

        // GET: VehicleMakeController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            return View(mapper.Map<VehicleMakeViewModel>(await vehicleMakeService.GetAsync(id)));
        }

        // POST: VehicleMakeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(VehicleMakeViewModel vehicleMakeViewModel)
        {
            try
            {
                await vehicleMakeService.UpdateAsync(mapper.Map<VehicleMakeDTO>(vehicleMakeViewModel));
                return RedirectToAction(nameof(VehicleMake));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleMakeController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            return View(mapper.Map<VehicleMakeViewModel>(await vehicleMakeService.GetAsync(id)));
        }

        // POST: VehicleMakeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(VehicleMakeViewModel vehicleMakeViewModel)
        {
            try
            {
                await vehicleMakeService.DeleteAsync(mapper.Map<VehicleMakeDTO>(vehicleMakeViewModel));
                return RedirectToAction(nameof(VehicleMake));
            }
            catch
            {
                return View();
            }
        }
    }
}
