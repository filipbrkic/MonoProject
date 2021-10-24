using MonoProject.Common.Interface;
using MonoProject.Common.Models;
using MonoProject.Repository.Common;
using MonoProject.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonoProject.Service
{
    public class VehicleEngineTypeService : IVehicleEngineTypeService
    {
        private readonly IVehicleEngineTypeRepository vehiceEngineTypeRepository;

        public VehicleEngineTypeService(IVehicleEngineTypeRepository vehiceEngineTypeRepository)
        {
            this.vehiceEngineTypeRepository = vehiceEngineTypeRepository;
        }

        public async Task<IEnumerable<VehicleEngineTypeDTO>> GetAllAsync(IFiltering filtering, IPaging paging, ISorting sorting)
        {
            return await vehiceEngineTypeRepository.GetAllAsync(filtering, paging, sorting);
        }

        public async Task<VehicleEngineTypeDTO> GetAsync(Guid id)
        {
            return await vehiceEngineTypeRepository.GetAsync(id);
        }
    }
}
