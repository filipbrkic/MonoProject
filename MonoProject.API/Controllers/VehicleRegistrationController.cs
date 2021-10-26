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
    [Route("api/vehicleregistration")]
    public class VehicleRegistrationController : ControllerBase
    {
        private readonly IVehicleRegistrationService vehicleRegistrationService;
        private readonly IMapper mapper;
        private readonly VehicleDbContext context;

        public VehicleRegistrationController(IVehicleRegistrationService vehicleRegistrationService, IMapper mapper, VehicleDbContext context)
        {
            this.vehicleRegistrationService = vehicleRegistrationService;
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet("{Id}", Name = "GetVehicleRegistration")]
        public async Task<IActionResult> GetVehicleRegistration(Guid id)
        {
            var vehicleRegistration = await vehicleRegistrationService.GetAsync(id);

            if (vehicleRegistration == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<VehicleRegistrationDTO>(vehicleRegistration));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVehicleRegistration([FromQuery] VehicleParams vehicleParams)
        {
            var filtering = new Filtering(vehicleParams.SearchBy, vehicleParams.Search);
            var paging = new Paging(vehicleParams.PageNumber, vehicleParams.PageSize);
            var sorting = new Sorting(vehicleParams.SortOrder, vehicleParams.SortyBy);

            dynamic obj = new ExpandoObject();
            obj.VehicleOwner = await vehicleRegistrationService.GetAllAsync(filtering, paging, sorting);
            obj.Filtering = filtering;
            obj.Pagination = paging;
            obj.Sorting = sorting;

            return Ok(JsonSerializer.Serialize(obj));
        }

        [HttpPost]
        public async Task<ActionResult<VehicleRegistrationDTO>> PostVehicleRegistration([FromQuery] VehicleParams vehicleParams)
        {
            var vehicleRegistration = mapper.Map<VehicleRegistrationDTO>(vehicleParams);
            vehicleRegistration.RegistrationNumber = "d";
            await vehicleRegistrationService.AddAsync(vehicleRegistration);

            return CreatedAtRoute("GetVehicleRegistration", new { id = vehicleRegistration.Id }, vehicleRegistration);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateVehicleRegistration(Guid id)
        {

            var vehicleGet = await vehicleRegistrationService.GetAsync(id);
            context.ChangeTracker.Clear();

            if (vehicleGet == null)
            {
                return NotFound();
            }

            var vehicleRegistration = mapper.Map<VehicleRegistrationDTO>(vehicleGet);
            await vehicleRegistrationService.UpdateAsync(vehicleRegistration);

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteVehicleRegistration(Guid id)
        {
            await vehicleRegistrationService.DeleteAsync(id);

            return NoContent();
        }
    }
}
