using Microsoft.EntityFrameworkCore.ChangeTracking;
using MonoProject.DAL.Models;
using MonoProject.Models;
using MonoProject.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonoProject.Service
{
    public class VehicleEngineTypeService : IVehicleEngineTypeService
    {
        private readonly IUnitOfWork unitOfWork;

        public VehicleEngineTypeService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<VehicleEngineTypeDTO>> GetAllAsync()
        {
            return await unitOfWork.VehicleEngineTypeRepository.GetAllAsync();
        }

        public async Task<VehicleEngineTypeDTO> GetAsync(Guid id)
        {
            return await unitOfWork.VehicleEngineTypeRepository.GetAsync(id);
        }

        public EntityEntry<VehicleEngineType> Add(VehicleEngineTypeDTO entity)
        {
            return unitOfWork.VehicleEngineTypeRepository.Add(entity);
        }
    }
}
