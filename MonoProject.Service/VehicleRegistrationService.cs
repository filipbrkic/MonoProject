using MonoProject.Common.Interface;
using MonoProject.Common.Models;
using MonoProject.Repository.Common;
using MonoProject.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonoProject.Service
{
    public class VehicleRegistrationService : IVehicleRegistrationService
    {
        private readonly IVehicleRegistrationRepository vehicleRegistrationRepository;

        public VehicleRegistrationService(IVehicleRegistrationRepository vehicleRegistrationRepository)
        {
            this.vehicleRegistrationRepository = vehicleRegistrationRepository;
        }

        public async Task<int> AddAsync(VehicleRegistrationDTO entity)
        {
            return await vehicleRegistrationRepository.AddAsync(entity);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await vehicleRegistrationRepository.DeleteAsync(id);
        }

        public async Task<int> DeleteAsync(VehicleRegistrationDTO entity)
        {
            return await vehicleRegistrationRepository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<VehicleRegistrationDTO>> GetAllAsync(IFiltering filtering, IPaging paging, ISorting sorting)
        {
            return await vehicleRegistrationRepository.GetAllAsync(filtering, paging, sorting);
        }

        public async Task<VehicleRegistrationDTO> GetAsync(Guid id)
        {
            return await vehicleRegistrationRepository.GetAsync(id);
        }

        public async Task<int> UpdateAsync(VehicleRegistrationDTO entity)
        {
            return await vehicleRegistrationRepository.UpdateAsync(entity);
        }
    }
}
