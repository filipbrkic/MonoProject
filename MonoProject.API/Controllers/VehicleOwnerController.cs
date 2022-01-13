using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MonoProject.API.Models;
using MonoProject.Common.Models;
using MonoProject.Service.Common;
using System;
using System.Threading.Tasks;

namespace MonoProject.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleOwnerController : ControllerBase
    {
        private readonly IVehicleOwnerService vehicleOwnerService;
        private readonly IMapper mapper;

        public VehicleOwnerController(IVehicleOwnerService vehicleOwnerService, IMapper mapper)
        {
            this.vehicleOwnerService = vehicleOwnerService;
            this.mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetVehicleOwnerAsync([FromQuery] Guid id)
        {
            var vehicleOwner = await vehicleOwnerService.GetAsync(id);

            if (vehicleOwner == null)
            {
                return BadRequest();
            }

            return Ok(vehicleOwner);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllVehicleOwnerAsync(string searchBy, string search, string sortOrder, string sortBy, int? pageNumber, int? pageSize)
        {
            var filtering = new Filtering(searchBy, search);
            var paging = new Paging(pageNumber, pageSize);
            var sorting = new Sorting(sortOrder, sortBy);

            var response = new PagedResult<VehicleOwnerDTO>()
            {
                Data = await vehicleOwnerService.GetAllAsync(filtering, paging, sorting),
                Filtering = filtering,
                Pagination = paging,
                Sorting = sorting,
            };

            return Ok(response);
        }   

        [HttpPost("[action]")]
        public async Task<ActionResult<VehicleOwnerDTO>> PostVehicleModelOwnerAsync([FromQuery] VehicleOwnerDTO vehicleOwnerDTO)
        {
            vehicleOwnerDTO.Id = Guid.NewGuid();
            var vehicleLink = mapper.Map<VehicleModelToVehicleOwnerLinkDTO>(vehicleOwnerDTO);
            var result = await vehicleOwnerService.AddAsync(vehicleOwnerDTO, vehicleLink);

            if (result == 0)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateVehicleOwnerAsync([FromBody] VehicleOwnerDTO vehicleOwnerDTO)
        {
            var result = await vehicleOwnerService.UpdateAsync(vehicleOwnerDTO);

            if (result == 0)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult> DeleteVehicleOwnerAsync([FromQuery] Guid id)
        {
            await vehicleOwnerService.DeleteAsync(id);

            return Ok();
        }
    }
}
