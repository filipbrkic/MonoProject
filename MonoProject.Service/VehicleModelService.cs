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
        private readonly IUnitOfWork unitOfWork;
        private readonly IVehicleModelRepository vehicleModelRepository;

        public VehicleModelService(IUnitOfWork unitOfWork, IVehicleModelRepository vehicleModelRepository)
        {
            this.unitOfWork = unitOfWork;
            this.vehicleModelRepository = vehicleModelRepository;
        }
        public async Task<IEnumerable<VehicleModelDTO>> GetAllAsync(IFiltering filtering, IPaging paging, ISorting sorting)
        {
            return await vehicleModelRepository.GetAllAsync(filtering, paging, sorting);
        }

        public async Task<int> AddAsync(VehicleModelDTO vehicleModel)
        {
            return await vehicleModelRepository.AddAsync(vehicleModel);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await unitOfWork.DeleteVehicleModelAsync(id);
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
