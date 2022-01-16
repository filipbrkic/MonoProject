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
    public class VehicleModelController : ControllerBase
    {
        private readonly IVehicleModelService vehicleModelService;
        private readonly IVehicleEngineTypeService vehicleEngineTypeService;

        public VehicleModelController(IVehicleModelService vehicleModelService, IVehicleEngineTypeService vehicleEngineTypeService)
        {
            this.vehicleModelService = vehicleModelService;
            this.vehicleEngineTypeService = vehicleEngineTypeService;
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


            var response = new PagedResult<VehicleModelDTO, VehicleEngineTypeDTO>()
            {
                Data = await vehicleModelService.GetAllAsync(filtering, paging, sorting),
                Filtering = filtering,
                Pagination = paging,
                Sorting = sorting,
                MetaData = await vehicleEngineTypeService.GetAllAsync(),
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
