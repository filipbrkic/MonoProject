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
    [Route("api/vehiclemodel")]
    public class VehicleModelController : ControllerBase
    {
        private readonly IVehicleModelService vehicleModelService;
        private readonly IMapper mapper;
        private readonly IVehicleMakeService vehicleMakeService;
        private readonly VehicleDbContext context;

        public VehicleModelController(IVehicleModelService vehicleModelService, IMapper mapper, IVehicleMakeService vehicleMakeService, VehicleDbContext context)
        {
            this.vehicleModelService = vehicleModelService;
            this.mapper = mapper;
            this.vehicleMakeService = vehicleMakeService;
            this.context = context;
        }
        [HttpGet("{Id}", Name = "GetVehicleModel")]
        public async Task<IActionResult> GetVehicleModel(Guid id)
        {
            var vehicleModel = await vehicleModelService.GetAsync(id);

            if (vehicleModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<VehicleModelDTO>(vehicleModel));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVehicleModel([FromQuery] VehicleParams vehicleParams)
        {
            var filtering = new Filtering(vehicleParams.SearchBy, vehicleParams.Search);
            var paging = new Paging(vehicleParams.PageNumber, vehicleParams.PageSize);
            var sorting = new Sorting(vehicleParams.SortOrder, vehicleParams.SortyBy);


            var vehicleModel = await vehicleModelService.GetAllAsync(filtering, paging, sorting);
            return Ok(JsonSerializer.Serialize(vehicleModel));
        }

        [HttpPost]
        public async Task<ActionResult<VehicleModelDTO>> PostVehicleModel([FromQuery] VehicleParams vehicleParams)
        {
            var vehicleModel = mapper.Map<VehicleModelDTO>(vehicleParams);
            vehicleModel.MakeId = vehicleParams.VehicleMakeId;
            await vehicleModelService.AddAsync(vehicleModel);

            return CreatedAtRoute("GetVehicleMake", new { id = vehicleModel.Id }, vehicleModel);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateVehicleModel(Guid id)
        {

            var vehicleGet = await vehicleModelService.GetAsync(id);
            context.ChangeTracker.Clear();

            if (vehicleGet == null)
            {
                return NotFound();
            }

            var vehicleModel = mapper.Map<VehicleModelDTO>(vehicleGet);

            await vehicleModelService.UpdateAsync(vehicleModel);


            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteVehicleModel(Guid id)
        {
            await vehicleModelService.DeleteAsync(id);

            return NoContent();
        }
    }

}
