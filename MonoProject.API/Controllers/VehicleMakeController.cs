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
    [Route("api/vehiclemake")]
    public class VehicleMakeController : ControllerBase
    {
        private readonly IVehicleMakeService vehicleMakeService;
        private readonly IMapper mapper;

        public VehicleMakeController(IVehicleMakeService vehicleMakeService, IMapper mapper)
        {
            this.vehicleMakeService = vehicleMakeService;
            this.mapper = mapper;
        }

        [HttpGet("{Id}", Name = "GetVehicleMake")]
        public async Task<IActionResult> GetVehicleMakeAsync(Guid id)
        {
            var vehicleMake = await vehicleMakeService.GetAsync(id);

            if (vehicleMake == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<VehicleMakeDTO>(vehicleMake));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVehicleMakeAsync([FromQuery] MakeParams makeParams)
        {
            var filtering = new Filtering(makeParams.SearchBy, makeParams.Search);
            var paging = new Paging(makeParams.PageNumber, makeParams.PageSize);
            var sorting = new Sorting(makeParams.SortOrder, makeParams.SortyBy);

            dynamic obj = new ExpandoObject();
            obj.VehicleMake = await vehicleMakeService.GetAllAsync(filtering, paging, sorting);
            obj.Filtering = filtering;
            obj.Pagination = paging;
            obj.Sorting = sorting;

            return Ok(JsonSerializer.Serialize(obj));
        }

        [HttpPost]
        public async Task<ActionResult<VehicleMakeDTO>> PostVehicleMakeAsync([FromQuery] MakeParams makeParams)
        {
            var vehicleMake = mapper.Map<VehicleMakeDTO>(makeParams);
            await vehicleMakeService.AddAsync(vehicleMake);

            return CreatedAtRoute("GetVehicleMake", new { id = vehicleMake.Id }, vehicleMake);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateVehicleMakeAsync(Guid id)
        {

            var vehicleGet = await vehicleMakeService.GetAsync(id);

            if (vehicleGet == null)
            {
                return NotFound();
            }

            var vehicleMake = mapper.Map<VehicleMakeDTO>(vehicleGet);
            await vehicleMakeService.UpdateAsync(vehicleMake);


            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteVehicleMakeAsync(Guid id)
        {
            await vehicleMakeService.DeleteAsync(id);

            return NoContent();
        }
    }
}
