using Microsoft.EntityFrameworkCore.ChangeTracking;
using MonoProject.Common.Interface;
using MonoProject.Common.Models;
using MonoProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonoProject.Service.Common
{
    public interface IVehicleRegistrationService
    {
        Task<IEnumerable<VehicleRegistrationDTO>> GetAllAsync(IFiltering filtering, IPaging paging, ISorting sorting);
        EntityEntry<VehicleRegistration> Add(VehicleRegistrationDTO entity);
        Task<VehicleRegistrationDTO> GetAsync(Guid id);
        EntityEntry<VehicleRegistration> Update(VehicleRegistrationDTO entity);
        Task<EntityEntry<VehicleRegistration>> DeleteAsync(Guid id);
        EntityEntry<VehicleRegistration> Delete(VehicleRegistrationDTO entity);
    }
}
