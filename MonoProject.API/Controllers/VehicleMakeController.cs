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
    [Route("[controller]")]
    public class VehicleMakeController : ControllerBase
    {
        private readonly IVehicleMakeService vehicleMakeService;
        private readonly IMapper mapper;

        public VehicleMakeController(IVehicleMakeService vehicleMakeService, IMapper mapper)
        {
            this.vehicleMakeService = vehicleMakeService;
            this.mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetVehicleMakeAsync([FromQuery] Guid id)
        {
            var vehicleMake = await vehicleMakeService.GetAsync(id);

            if (vehicleMake == null)
            {
                return BadRequest();
            }

            return Ok(mapper.Map<VehicleMakeDTO>(vehicleMake));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllVehicleMakeAsync(string searchBy, string search, string sortOrder, string sortBy, int? pageNumber, int? pageSize)
        {
            var filtering = new Filtering(searchBy, search);
            var paging = new Paging(pageNumber, pageSize);
            var sorting = new Sorting(sortOrder, sortBy);

            var response = new PagedResult<VehicleMakeDTO>()
            {
                Data = await vehicleMakeService.GetAllAsync(filtering, paging, sorting),
                Filtering = filtering,
                Pagination = paging,
                Sorting = sorting,
            };

            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> PostVehicleMakeAsync([FromBody] VehicleMakeDTO vehicleMakeDTO)
        {
            var result = await vehicleMakeService.AddAsync(vehicleMakeDTO);

            if (result == 0)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateVehicleMakeAsync([FromBody] VehicleMakeDTO vehicleMakeDTO)
        {
            var vehicleGet = await vehicleMakeService.GetAsync(vehicleMakeDTO.Id);

            if (vehicleGet == null)
            {
                return BadRequest();
            }

            await vehicleMakeService.UpdateAsync(vehicleMakeDTO);

            return Ok();
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult> DeleteVehicleMakeAsync([FromQuery] Guid id)
        {
            await vehicleMakeService.DeleteAsync(id);

            return Ok();
        }
    }
}
