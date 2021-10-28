using MonoProject.Common.Interface;
using MonoProject.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonoProject.Service.Common
{
    public interface IVehicleEngineTypeService
    {
        Task<IEnumerable<VehicleEngineTypeDTO>> GetAllAsync(IFiltering filtering, IPaging paging, ISorting sorting);
        Task<VehicleEngineTypeDTO> GetAsync(Guid id);
        Task<int> AddAsync(VehicleEngineTypeDTO entity);
    }
}
