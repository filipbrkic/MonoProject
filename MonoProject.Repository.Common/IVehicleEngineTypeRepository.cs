using Microsoft.EntityFrameworkCore.ChangeTracking;
using MonoProject.Models;
using MonoProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonoProject.Repository.Common
{
    public interface IVehicleEngineTypeRepository
    {
        Task<IEnumerable<VehicleEngineTypeDTO>> GetAllAsync();
        Task<VehicleEngineTypeDTO> GetAsync(Guid id);
        EntityEntry<VehicleEngineType> Add(VehicleEngineTypeDTO entity);
        Task<EntityEntry<VehicleEngineType>> DeleteAsync(Guid id);
        EntityEntry<VehicleEngineType> DeleteAsync(VehicleEngineTypeDTO entity);
    }
}
