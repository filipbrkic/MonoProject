using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonoProject.Common.Models;
using MonoProject.DAL.Models;
using MonoProject.MVC.Models;
using MonoProject.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonoProject.MVC.Controllers
{
    public class VehicleModelController : Controller
    {
        private readonly IMapper mapper;
        private readonly IVehicleModelService vehicleModelService;

        public VehicleModelController(IMapper mapper, IVehicleModelService vehicleModelService)
        {
            this.mapper = mapper;
            this.vehicleModelService = vehicleModelService;
        }

        // GET: VehicleModelController
        public ActionResult Index()
        {
            return View();
        }

        // GET: VehicleModelController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var result = await vehicleModelService.GetAsync(id);
            return View();
        }

        // GET: VehicleModelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleModelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(VehicleModelViewModel vehicleModelViewModel)
        {
            try
            {
                await vehicleModelService.AddAsync(mapper.Map<VehicleModelDTO>(vehicleModelService));
                return RedirectToAction(nameof(VehicleModel));
            }
            catch
            {
                return RedirectToAction(nameof(VehicleModel));
            }
        }   

        // GET: VehicleModelController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            return View(mapper.Map<VehicleModelViewModel>(await vehicleModelService.GetAsync(id)));
        }

        // POST: VehicleModelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(VehicleModelViewModel vehicleModelViewModel)
        {
            try
            {
                await vehicleModelService.UpdateAsync(mapper.Map<VehicleModelDTO>(vehicleModelViewModel));
                return RedirectToAction(nameof(VehicleModel));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleModelController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            return View(mapper.Map<VehicleModelViewModel>(await vehicleModelService.GetAsync(id)));
        }

        // POST: VehicleModelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(VehicleModelViewModel vehicleModelViewModel)
        {
            try
            {
                await vehicleModelService.DeleteAsync(mapper.Map<VehicleModelDTO>(vehicleModelViewModel));
                return RedirectToAction(nameof(VehicleModel));
            }
            catch
            {
                return View();
            }
        }
    }
}
