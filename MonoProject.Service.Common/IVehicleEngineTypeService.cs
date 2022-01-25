using Microsoft.EntityFrameworkCore.ChangeTracking;
using MonoProject.Common.Models;
using MonoProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonoProject.Service.Common
{
    public interface IVehicleEngineTypeService
    {
        Task<IEnumerable<VehicleEngineTypeDTO>> GetAllAsync();
        Task<VehicleEngineTypeDTO> GetAsync(Guid id);
        EntityEntry<VehicleEngineType> Add(VehicleEngineTypeDTO entity);
    }
}
