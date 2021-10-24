using MonoProject.Common.Interface;
using MonoProject.Common.Models;
using MonoProject.Repository.Common;
using MonoProject.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonoProject.Service
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly IVehicleModelRepository vehicleModelRepository;

        public VehicleModelService(IVehicleModelRepository vehicleModelRepository)
        {
            this.vehicleModelRepository = vehicleModelRepository;
        }
        public async Task<IEnumerable<VehicleModelDTO>> GetAllAsync(IFiltering filtering, IPaging paging, ISorting sorting)
        {
            return await vehicleModelRepository.GetAllAsync(filtering, paging, sorting);
        }

        public async Task<int> AddAsync(VehicleModelDTO entity)
        {
            return await vehicleModelRepository.AddAsync(entity);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await vehicleModelRepository.DeleteAsync(id);
        }

        public async Task<int> DeleteAsync(VehicleModelDTO entity)
        {
            return await vehicleModelRepository.DeleteAsync(entity);
        }

        public async Task<VehicleModelDTO> GetAsync(Guid id)
        {
            return await vehicleModelRepository.GetAsync(id);
        }

        public async Task<int> UpdateAsync(VehicleModelDTO entity)
        {
            return await vehicleModelRepository.UpdateAsync(entity);
        }
    }
}
