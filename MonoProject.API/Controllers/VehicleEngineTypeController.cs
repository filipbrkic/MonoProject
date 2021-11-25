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
    [Route("api/vehicleenginetype")]
    public class VehicleEngineTypeController : ControllerBase
    {
        private readonly IVehicleEngineTypeService vehicleEngineTypeService;
        private readonly IMapper mapper;

        public VehicleEngineTypeController(IVehicleEngineTypeService vehicleEngineTypeService, IMapper mapper)
        {
            this.vehicleEngineTypeService = vehicleEngineTypeService;
            this.mapper = mapper;
        }

        [HttpGet("{Id}", Name = "GetVehicleEngineTypeController")]
        public async Task<IActionResult> GetVehicleEngineTypeAsync(Guid id)
        {
            var vehicleRegistration = await vehicleEngineTypeService.GetAsync(id);

            if (vehicleRegistration == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<VehicleEngineTypeDTO>(vehicleRegistration));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVehicleEngineTypeAsync([FromQuery] EngineTypeParams engineTypeParams)
        {
            var filtering = new Filtering(engineTypeParams.SearchBy, engineTypeParams.Search);
            var paging = new Paging(engineTypeParams.PageNumber, engineTypeParams.PageSize);
            var sorting = new Sorting(engineTypeParams.SortOrder, engineTypeParams.SortyBy);

            dynamic obj = new ExpandoObject();
            obj.VehicleOwner = await vehicleEngineTypeService.GetAllAsync(filtering, paging, sorting);
            obj.Filtering = filtering;
            obj.Pagination = paging;
            obj.Sorting = sorting;

            return Ok(JsonSerializer.Serialize(obj));
        }

        [HttpPost]
        public async Task<ActionResult<VehicleEngineTypeDTO>> PostVehicleMakeAsync([FromQuery] EngineTypeParams engineTypeParams)
        {
            engineTypeParams.Id = Guid.NewGuid();
            var vehicleEngineType = mapper.Map<VehicleEngineTypeDTO>(engineTypeParams);
            await vehicleEngineTypeService.AddAsync(vehicleEngineType);

            return CreatedAtRoute("GetVehicleEngineTypeController", new { id = vehicleEngineType.Id }, vehicleEngineType);
        }
    }
}
