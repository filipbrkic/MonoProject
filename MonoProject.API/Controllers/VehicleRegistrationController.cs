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
    [Route("api/vehicleregistration")]
    public class VehicleRegistrationController : ControllerBase
    {
        private readonly IVehicleRegistrationService vehicleRegistrationService;
        private readonly IMapper mapper;

        public VehicleRegistrationController(IVehicleRegistrationService vehicleRegistrationService, IMapper mapper)
        {
            this.vehicleRegistrationService = vehicleRegistrationService;
            this.mapper = mapper;
        }

        [HttpGet("{Id}", Name = "GetVehicleRegistration")]
        public async Task<IActionResult> GetVehicleRegistrationAsync(Guid id)
        {
            var vehicleRegistration = await vehicleRegistrationService.GetAsync(id);

            if (vehicleRegistration == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<VehicleRegistrationDTO>(vehicleRegistration));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVehicleRegistrationAsync([FromQuery] RegistrationParams registrationParams)
        {
            var filtering = new Filtering(registrationParams.SearchBy, registrationParams.Search);
            var paging = new Paging(registrationParams.PageNumber, registrationParams.PageSize);
            var sorting = new Sorting(registrationParams.SortOrder, registrationParams.SortyBy);

            dynamic obj = new ExpandoObject();
            obj.VehicleOwner = await vehicleRegistrationService.GetAllAsync(filtering, paging, sorting);
            obj.Filtering = filtering;
            obj.Pagination = paging;
            obj.Sorting = sorting;

            return Ok(JsonSerializer.Serialize(obj));
        }

        [HttpPost]
        public async Task<ActionResult<VehicleRegistrationDTO>> PostVehicleRegistrationAsync([FromQuery] RegistrationParams registrationParams)
        {
            var vehicleRegistration = mapper.Map<VehicleRegistrationDTO>(registrationParams);
            var vehicleLink = mapper.Map<VehicleModelToVehicleOwnerLinkDTO>(registrationParams);
            await vehicleRegistrationService.AddAsync(vehicleRegistration, vehicleLink);

            return CreatedAtRoute("GetVehicleRegistration", new { id = vehicleRegistration.Id }, vehicleRegistration);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateVehicleRegistrationAsync(Guid id)
        {

            var vehicleGet = await vehicleRegistrationService.GetAsync(id);

            if (vehicleGet == null)
            {
                return NotFound();
            }

            var vehicleRegistration = mapper.Map<VehicleRegistrationDTO>(vehicleGet);
            await vehicleRegistrationService.UpdateAsync(vehicleRegistration);

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteVehicleRegistrationAsync(Guid id)
        {
            await vehicleRegistrationService.DeleteAsync(id);

            return NoContent();
        }
    }
}
