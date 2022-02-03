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
    public class VehicleModelController : ControllerBase
    {
        private readonly IVehicleModelService vehicleModelService;
        private readonly IVehicleEngineTypeService vehicleEngineTypeService;
        private readonly IMapper mapper;

        public VehicleModelController(IVehicleModelService vehicleModelService, IVehicleEngineTypeService vehicleEngineTypeService, IMapper mapper)
        {
            this.vehicleModelService = vehicleModelService;
            this.vehicleEngineTypeService = vehicleEngineTypeService;
            this.mapper = mapper;
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

            var vehicleModelList = await vehicleModelService.GetAllAsync(filtering, paging, sorting);
            var vehicleModel = mapper.Map<IEnumerable<VehicleModelDVO>>(vehicleModelList);

            var vehicleEngineTypeList = await vehicleEngineTypeService.GetAllAsync();
            var vehicleEngineType = mapper.Map<IEnumerable<VehicleEngineTypeDVO>>(vehicleEngineTypeList);

            var response = new PagedResult<VehicleModelDVO, VehicleEngineTypeDVO>()
            {
                Data = vehicleModel,
                Filtering = filtering,
                Pagination = paging,
                Sorting = sorting,
                MetaData = vehicleEngineType,
            };

            return Ok(response);
        }

        [HttpPost("[action]")]
        public ActionResult PostVehicleModel([FromBody] VehicleModelDVO vehicleModelDVO)
        {
            var vehicleModel = mapper.Map<VehicleModelDTO>(vehicleModelDVO);
            var result = vehicleModelService.Add(vehicleModel);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut("[action]")]
        public IActionResult UpdateVehicleModel([FromBody] VehicleModelDVO vehicleModelDVO)
        {
            var vehicleModel = mapper.Map<VehicleModelDTO>(vehicleModelDVO);

            var result = vehicleModelService.Update(vehicleModel);

            if (result == null)
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
