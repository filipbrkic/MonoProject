using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MonoProject.API.Models;
using MonoProject.Common.Models;
using MonoProject.DAL.Data;
using MonoProject.Service.Common;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace MonoProject.API.Controllers
{
    [ApiController]
    [Route("api/vehiclemake/")]
    public class VehicleMakeController : ControllerBase
    {
        private readonly IVehicleMakeService vehicleMakeService;
        private readonly IMapper mapper;
        private readonly VehicleDbContext context;

        public VehicleMakeController(IVehicleMakeService vehicleMakeService, IMapper mapper, VehicleDbContext context)
        {
            this.vehicleMakeService = vehicleMakeService;
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet("{Id}", Name = "GetVehicleMake")]
        public async Task<IActionResult> GetVehicleMake(Guid id)
        {
            var vehicleMake = await vehicleMakeService.GetAsync(id);

            if (vehicleMake == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<VehicleMakeDTO>(vehicleMake));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVehicleMake([FromQuery] VehicleParams vehicleParams)
        {
            var filtering = new Filtering(vehicleParams.searchBy, vehicleParams.search);
            var paging = new Paging(vehicleParams.pageNumber, vehicleParams.pageSize);
            var sorting = new Sorting(vehicleParams.sortOrder, vehicleParams.sortyBy);


            var vehicleMake = await vehicleMakeService.GetAllAsync(filtering, paging, sorting);
            return Ok(JsonSerializer.Serialize(vehicleMake));
        }

        [HttpPost]
        public async Task<ActionResult<VehicleMakeDTO>> PostVehicleMake([FromQuery] VehicleParams vehicleParams)
        {
            var vehicleMake = mapper.Map<VehicleMakeDTO>(vehicleParams);
            await vehicleMakeService.AddAsync(vehicleMake);

            return CreatedAtRoute("GetVehicleMake", new { id = vehicleMake.Id }, vehicleMake);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateVehicleMake(Guid id)
        {

            var vehicleGet = await vehicleMakeService.GetAsync(id);
            context.ChangeTracker.Clear();

            if (vehicleGet == null)
            {
                return NotFound();
            }

            var vehicleMake = mapper.Map<VehicleMakeDTO>(vehicleGet);

            await vehicleMakeService.UpdateAsync(vehicleMake);


            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteVehicleMake(Guid id)
        {
            await vehicleMakeService.DeleteAsync(id);

            return NoContent();
        }
    }
}
