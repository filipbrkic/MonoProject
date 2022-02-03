using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MonoProject.API.Models;
using MonoProject.Common.Models;
using MonoProject.Service.Common;
using System;
using System.Collections.Generic;
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

            return Ok(vehicleMake);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllVehicleMakeAsync(string searchBy, string search, string sortOrder, string sortBy, int? pageNumber, int? pageSize)
        {
            var filtering = new Filtering(searchBy, search);
            var paging = new Paging(pageNumber, pageSize);
            var sorting = new Sorting(sortOrder, sortBy);

            var vehicleMakeList = await vehicleMakeService.GetAllAsync(filtering, paging, sorting);
            var vehicleMake = mapper.Map<IEnumerable<VehicleMakeDVO>>(vehicleMakeList);

            var response = new PagedResult<VehicleMakeDVO, object>()
            {
                Data = vehicleMake,
                Filtering = filtering,
                Pagination = paging,
                Sorting = sorting,
            };

            return Ok(response);
        }

        [HttpPost("[action]")]
        public ActionResult PostVehicleMake([FromBody] VehicleMakeDVO vehicleMakeDVO)
        {
            try
            {
                var vehicleMake = mapper.Map<VehicleMakeDTO>(vehicleMakeDVO);

                var result = vehicleMakeService.Add(vehicleMake);

                if (result == null)
                {
                    return BadRequest();
                }

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("[action]")]
        public IActionResult UpdateVehicleMake([FromBody] VehicleMakeDVO vehicleMakeDVO)
        {
            var vehicleMake = mapper.Map<VehicleMakeDTO>(vehicleMakeDVO);

            var result = vehicleMakeService.Update(vehicleMake);

            if (result == null)
            {
                return BadRequest();
            }

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
