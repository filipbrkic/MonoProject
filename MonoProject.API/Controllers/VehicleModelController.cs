using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MonoProject.API.Models;
using MonoProject.Common.Models;
using MonoProject.Service.Common;
using System;
using System.Dynamic;
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

        public VehicleModelController(IVehicleModelService vehicleModelService, IMapper mapper, IVehicleMakeService vehicleMakeService)
        {
            this.vehicleModelService = vehicleModelService;
            this.mapper = mapper;
            this.vehicleMakeService = vehicleMakeService;
        }

        [HttpGet("{Id}", Name = "GetVehicleModel")]
        public async Task<IActionResult> GetVehicleModelAsync(Guid id)
        {
            var vehicleModel = await vehicleModelService.GetAsync(id);

            if (vehicleModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<VehicleModelDTO>(vehicleModel));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVehicleModelAsync([FromQuery] ModelParams modelParams)
        {
            var filtering = new Filtering(modelParams.SearchBy, modelParams.Search);
            var paging = new Paging(modelParams.PageNumber, modelParams.PageSize);
            var sorting = new Sorting(modelParams.SortOrder, modelParams.SortyBy);

            dynamic obj = new ExpandoObject();
            obj.VehicleModel = await vehicleModelService.GetAllAsync(filtering, paging, sorting);
            obj.Filtering = filtering;
            obj.Pagination = paging;
            obj.Sorting = sorting;

            return Ok(JsonSerializer.Serialize(obj));
        }

        [HttpPost]
        public async Task<ActionResult<VehicleModelDTO>> PostVehicleModelAsync([FromQuery] ModelParams modelParams)
        {
            var vehicleModel = mapper.Map<VehicleModelDTO>(modelParams);
            vehicleModel.MakeId = modelParams.MakeId;
            vehicleModel.EngineTypeId = modelParams.EngineTypeId;

           // vehicleModel.MakeId = Guid.Parse("d3d7cde9-e980-4764-9230-f5c38a85ebda");
           // vehicleModel.EngineTypeId = Guid.Parse("5d3dd068-f321-4e35-8f87-91d9c23845e0"); FOR TESTING IN POSTMAN
            await vehicleModelService.AddAsync(vehicleModel);

            return CreatedAtRoute("GetVehicleMake", new { id = vehicleModel.Id, modelParams.MakeId, modelParams.EngineTypeId }, vehicleModel);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateVehicleModelAsync(Guid id)
        {

            var vehicleGet = await vehicleModelService.GetAsync(id);

            if (vehicleGet == null)
            {
                return NotFound();
            }

            var vehicleModel = mapper.Map<VehicleModelDTO>(vehicleGet);
            // vehicleModel.Name = "x";
            // vehicleModel.Abrv = "y";         USED FOR TESTING IN POSTMAN
            await vehicleModelService.UpdateAsync(vehicleModel);


            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteVehicleModelAsync(Guid id)
        {
            await vehicleModelService.DeleteAsync(id);

            return NoContent();
        }
    }

}
