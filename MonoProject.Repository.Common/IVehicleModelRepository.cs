using MonoProject.Common.Interface;
using MonoProject.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonoProject.Repository.Common
{
    public interface IVehicleModelRepository
    {
        Task<int> AddAsync(VehicleModelDTO entity);
        Task<IEnumerable<VehicleModelDTO>> GetAllAsync(IFiltering filtering, IPaging paging, ISorting sorting);
        Task<VehicleModelDTO> GetAsync(Guid id);
        Task<int> UpdateAsync(VehicleModelDTO entity);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(VehicleModelDTO entity);
    }
}
