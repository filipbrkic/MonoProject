using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MonoProject.Common.Models;
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
        private readonly IVehicleMakeService vehicleMakeService;

        public VehicleModelController(IMapper mapper, IVehicleModelService vehicleModelService, IVehicleMakeService vehicleMakeService)
        {
            this.mapper = mapper;
            this.vehicleModelService = vehicleModelService;
            this.vehicleMakeService = vehicleMakeService;
        }

        // GET: VehicleModelController
        [HttpGet("VehicleModel", Name = "get-vehiclemodel")]
        public async Task<ActionResult> VehicleModel(string sortOrder, string sortBy, string searchBy, string search, int? pageNumber, int? pageSize)
        {
            var paging = new Paging(pageNumber, pageSize);

            sortOrder = string.IsNullOrEmpty(sortOrder) ? "asc" : sortOrder;
            ViewBag.Sorting = sortOrder;
            ViewBag.SortBy = sortBy;
            ViewBag.Search = !string.IsNullOrEmpty(search) ? search : "";
            ViewBag.SearchBy = !string.IsNullOrEmpty(searchBy) ? searchBy : "Name";
            ViewBag.CurrentPage = paging.PageNumber;
            ViewBag.PageSize = paging.PageSize;

            var result = await vehicleModelService.GetAllAsync(new Filtering(searchBy, search), paging, new Sorting(sortOrder, sortBy));

            var pageCount = paging.TotalItemsCount / paging.PageSize;
            ViewBag.TotalPageCount = paging.TotalItemsCount % paging.PageSize == 0 ? pageCount : pageCount + 1;

            return View(mapper.Map<IEnumerable<VehicleModelViewModel>>(result));
        }

        // GET: VehicleModelController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var result = await vehicleModelService.GetAsync(id);
            return View();
        }

        // GET: VehicleModelController/Create
        public async Task<ActionResult> Create()
        {
            var makes = await vehicleMakeService.GetAllAsync(new Filtering("Name", string.Empty), new Paging(1,100), new Sorting("asc","Name"));
            ViewBag.Makes = makes.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            }).ToList();
            return View();
        }

        // POST: VehicleModelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(VehicleModelViewModel vehicleModelViewModel)
        {
            try
            {
                await vehicleModelService.AddAsync(mapper.Map<VehicleModelDTO>(vehicleModelViewModel));
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
            var makes = await vehicleMakeService.GetAllAsync(new Filtering("Name", string.Empty), new Paging(1, 100), new Sorting("asc", "Name"));
            ViewBag.Makes = makes.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            }).ToList();
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
