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
        public async Task<IActionResult> GetVehicleEngineTypeController(Guid id)
        {
            var vehicleRegistration = await vehicleEngineTypeService.GetAsync(id);

            if (vehicleRegistration == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<VehicleEngineTypeDTO>(vehicleRegistration));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVehicleEngineTypeController([FromQuery] VehicleParams vehicleParams)
        {
            var filtering = new Filtering(vehicleParams.SearchBy, vehicleParams.Search);
            var paging = new Paging(vehicleParams.PageNumber, vehicleParams.PageSize);
            var sorting = new Sorting(vehicleParams.SortOrder, vehicleParams.SortyBy);

            dynamic obj = new ExpandoObject();
            obj.VehicleOwner = await vehicleEngineTypeService.GetAllAsync(filtering, paging, sorting);
            obj.Filtering = filtering;
            obj.Pagination = paging;
            obj.Sorting = sorting;

            return Ok(JsonSerializer.Serialize(obj));
        }
    }
}
