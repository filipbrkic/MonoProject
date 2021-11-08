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
    [Route("api/vehicleowner")]
    public class VehicleOwnerController : ControllerBase
    {
        private readonly IVehicleOwnerService vehicleOwnerService;
        private readonly IMapper mapper;

        public VehicleOwnerController(IVehicleOwnerService vehicleOwnerService, IMapper mapper)
        {
            this.vehicleOwnerService = vehicleOwnerService;
            this.mapper = mapper;
        }

        [HttpGet("{Id}", Name = "GetVehicleOwner")]
        public async Task<IActionResult> GetVehicleOwnerAsync(Guid id)
        {
            var vehicleOwner = await vehicleOwnerService.GetAsync(id);

            if (vehicleOwner == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<VehicleOwnerDTO>(vehicleOwner));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVehicleOwnerAsync([FromQuery] OwnerParams ownerParams)
        {
            var filtering = new Filtering(ownerParams.SearchBy, ownerParams.Search);
            var paging = new Paging(ownerParams.PageNumber, ownerParams.PageSize);
            var sorting = new Sorting(ownerParams.SortOrder, ownerParams.SortyBy);

            dynamic obj = new ExpandoObject();
            obj.VehicleOwner = await vehicleOwnerService.GetAllAsync(filtering, paging, sorting);
            obj.Filtering = filtering;
            obj.Pagination = paging;
            obj.Sorting = sorting;

            return Ok(JsonSerializer.Serialize(obj));
        }   

        [HttpPost]
        public async Task<ActionResult<VehicleOwnerDTO>> PostVehicleOwnerAsync([FromQuery] OwnerParams ownerParams)
        {
            var vehicleOwner = mapper.Map<VehicleOwnerDTO>(ownerParams);
            vehicleOwner.Id = Guid.NewGuid();
            var vehicleLink = mapper.Map<VehicleModelToVehicleOwnerLinkDTO>(ownerParams);
            vehicleLink.OwnerId = vehicleOwner.Id;
            await vehicleOwnerService.AddAsync(vehicleOwner, vehicleLink);

            return CreatedAtRoute("GetVehicleOwner", new { id = vehicleOwner.Id, vehicleLink.OwnerId }, (vehicleOwner, vehicleLink));
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateVehicleOwnerAsync(Guid id)
        {

            var vehicleGet = await vehicleOwnerService.GetAsync(id);

            if (vehicleGet == null)
            {
                return NotFound();
            }

            var vehicleOwner = mapper.Map<VehicleOwnerDTO>(vehicleGet);

            await vehicleOwnerService.UpdateAsync(vehicleOwner);

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteVehicleOwnerAsync(Guid id)
        {
            await vehicleOwnerService.DeleteAsync(id);

            return NoContent();
        }
    }
}
