using MonoProject.Common.Interface;
using MonoProject.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonoProject.Service.Common
{
    public interface IVehicleOwnerService
    {
        Task<IEnumerable<VehicleOwnerDTO>> GetAllAsync(IFiltering filtering, IPaging paging, ISorting sorting);
        Task<int> AddAsync(VehicleOwnerDTO entity, VehicleModelToVehicleOwnerLinkDTO link);
        Task<VehicleOwnerDTO> GetAsync(Guid id);
        Task<int> UpdateAsync(VehicleOwnerDTO entity);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(VehicleOwnerDTO entity);
    }
}
