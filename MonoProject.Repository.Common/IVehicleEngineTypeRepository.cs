using MonoProject.Common.Interface;
using MonoProject.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonoProject.Repository.Common
{
    public interface IVehicleEngineTypeRepository
    {
        Task<IEnumerable<VehicleEngineTypeDTO>> GetAllAsync(IFiltering filtering, IPaging paging, ISorting sorting);
        Task<VehicleEngineTypeDTO> GetAsync(Guid id);
        Task<int> AddAsync(VehicleEngineTypeDTO entity);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(VehicleEngineTypeDTO entity);
    }
}
