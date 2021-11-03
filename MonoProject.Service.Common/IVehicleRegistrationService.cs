using MonoProject.Common.Interface;
using MonoProject.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonoProject.Service.Common
{
    public interface IVehicleRegistrationService
    {
        Task<IEnumerable<VehicleRegistrationDTO>> GetAllAsync(IFiltering filtering, IPaging paging, ISorting sorting);
        Task<int> AddAsync(VehicleRegistrationDTO entity, VehicleModelToVehicleOwnerLinkDTO link);
        Task<VehicleRegistrationDTO> GetAsync(Guid id);
        Task<int> UpdateAsync(VehicleRegistrationDTO entity);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(VehicleRegistrationDTO entity);
    }
}
