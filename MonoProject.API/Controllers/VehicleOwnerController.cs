using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MonoProject.API.Models;
using MonoProject.Common.Models;
using MonoProject.Models;
using MonoProject.Service.Common;
using System;
using System.Collections.Generic;
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

            var vehicleOwnerList = await vehicleOwnerService.GetAllAsync(filtering, paging, sorting);
            var vehicleOwner = mapper.Map<IEnumerable<VehicleOwnerDVO>>(vehicleOwnerList);

            var response = new PagedResult<VehicleOwnerDVO, object>()
            {
                Data = vehicleOwner,
                Filtering = filtering,
                Pagination = paging,
                Sorting = sorting,
            };

            return Ok(response);
        }   

        [HttpPost("[action]")]
        public ActionResult PostVehicleOwner([FromQuery] VehicleOwnerDVO vehicleOwnerDVO)
        {
            var vehicleOwner = mapper.Map<VehicleOwnerDTO>(vehicleOwnerDVO);
            var result = vehicleOwnerService.Add(vehicleOwner);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut("[action]")]
        public IActionResult UpdateVehicleOwner([FromBody] VehicleOwnerDVO vehicleOwnerDVO)
        {
            var vehicleOwner = mapper.Map<VehicleOwnerDTO>(vehicleOwnerDVO);

            var result = vehicleOwnerService.Update(vehicleOwner);

            if (result == null)
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
