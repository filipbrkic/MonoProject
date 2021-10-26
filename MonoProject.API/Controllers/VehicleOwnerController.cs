using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MonoProject.API.Models;
using MonoProject.Common.Models;
using MonoProject.DAL.Data;
using MonoProject.Service.Common;
using System;
using System.Dynamic;
using System.Text.Json;
using System.Threading.Tasks;

namespace MonoProject.API.Controllers
{
    [ApiController]
    [Route("api/vehicleowner")]
    public class VehicleOwnerController : ControllerBase
    {
        private readonly IVehicleOwnerService vehicleOwnerService;
        private readonly IMapper mapper;
        private readonly VehicleDbContext context;

        public VehicleOwnerController(IVehicleOwnerService vehicleOwnerService, IMapper mapper, VehicleDbContext context)
        {
            this.vehicleOwnerService = vehicleOwnerService;
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet("{Id}", Name = "GetVehicleOwner")]
        public async Task<IActionResult> GetVehicleOwner(Guid id)
        {
            var vehicleOwner = await vehicleOwnerService.GetAsync(id);

            if (vehicleOwner == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<VehicleOwnerDTO>(vehicleOwner));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVehicleOwner([FromQuery] VehicleParams vehicleParams)
        {
            var filtering = new Filtering(vehicleParams.SearchBy, vehicleParams.Search);
            var paging = new Paging(vehicleParams.PageNumber, vehicleParams.PageSize);
            var sorting = new Sorting(vehicleParams.SortOrder, vehicleParams.SortyBy);

            dynamic obj = new ExpandoObject();
            obj.VehicleOwner = await vehicleOwnerService.GetAllAsync(filtering, paging, sorting);
            obj.Filtering = filtering;
            obj.Pagination = paging;
            obj.Sorting = sorting;

            return Ok(JsonSerializer.Serialize(obj));
        }

        [HttpPost]
        public async Task<ActionResult<VehicleOwnerDTO>> PostVehicleOwner([FromQuery] VehicleParams vehicleParams)
        {
            var vehicleOwner = mapper.Map<VehicleOwnerDTO>(vehicleParams);
            await vehicleOwnerService.AddAsync(vehicleOwner);

            return CreatedAtRoute("GetVehicleOwner", new { id = vehicleOwner.Id }, vehicleOwner);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateVehicleOwner(Guid id)
        {

            var vehicleGet = await vehicleOwnerService.GetAsync(id);
            context.ChangeTracker.Clear();

            if (vehicleGet == null)
            {
                return NotFound();
            }

            var vehicleOwner = mapper.Map<VehicleOwnerDTO>(vehicleGet);

            await vehicleOwnerService.UpdateAsync(vehicleOwner);

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteVehicleOwner(Guid id)
        {
            await vehicleOwnerService.DeleteAsync(id);

            return NoContent();
        }
    }
}
