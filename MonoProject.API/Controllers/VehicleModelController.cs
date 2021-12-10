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

        [HttpGet("[action]")]
        public async Task<IActionResult> GetVehicleModelAsync([FromQuery] Guid id)
        {
            var vehicleModel = await vehicleModelService.GetAsync(id);

            if (vehicleModel == null)
            {
                return BadRequest();
            }

            return Ok(vehicleModel);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllVehicleModelAsync(string searchBy, string search, string sortOrder, string sortBy, int? pageNumber, int? pageSize)
        {
            var filtering = new Filtering(searchBy, search);
            var paging = new Paging(pageNumber, pageSize);
            var sorting = new Sorting(sortOrder, sortBy);

            var response = new PagedResult<VehicleModelDTO>()
            {
                Data = await vehicleModelService.GetAllAsync(filtering, paging, sorting),
                Filtering = filtering,
                Pagination = paging,
                Sorting = sorting,
            };

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<VehicleModelDTO>> PostVehicleModelAsync([FromBody] VehicleModelDTO vehicleModelDTO)
        {
            vehicleModelDTO.Id = Guid.NewGuid();

            var result = await vehicleModelService.AddAsync(vehicleModelDTO);

            if (result == 0)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateVehicleModelAsync([FromBody] VehicleModelDTO vehicleModelDTO)
        {
            var result = await vehicleModelService.UpdateAsync(vehicleModelDTO);

            if (result == 0)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult> DeleteVehicleModelAsync([FromQuery] Guid id)
        {
            await vehicleModelService.DeleteAsync(id);

            return Ok();
        }
    }

}
