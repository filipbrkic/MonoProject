using MonoProject.Common.Interface;
using MonoProject.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonoProject.Repository.Common
{
    public interface IVehicleOwnerRepository
    {
        Task<int> AddAsync(VehicleOwnerDTO entity);
        Task<IEnumerable<VehicleOwnerDTO>> GetAllAsync(IFiltering filtering, IPaging paging, ISorting sorting);
        Task<VehicleOwnerDTO> GetAsync(Guid id);
        Task<int> UpdateAsync(VehicleOwnerDTO entity);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(VehicleOwnerDTO entity);
    }
}
