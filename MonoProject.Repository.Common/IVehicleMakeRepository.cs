using MonoProject.Common.Interface;
using MonoProject.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonoProject.Repository.Common
{
    public interface IVehicleMakeRepository
    {
        Task<int> AddAsync(VehicleMakeDTO entity);
        Task<IEnumerable<VehicleMakeDTO>> GetAllAsync(IFiltering filtering, IPaging paging, ISorting sorting);
        Task<VehicleMakeDTO> GetAsync(Guid id);
        Task<int> UpdateAsync(VehicleMakeDTO entity);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(VehicleMakeDTO entity);
    }
}
