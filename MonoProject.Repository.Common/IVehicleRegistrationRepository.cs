using Microsoft.EntityFrameworkCore.ChangeTracking;
using MonoProject.Common.Interface;
using MonoProject.Common.Models;
using MonoProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MonoProject.Repository.Common
{
    public interface IVehicleRegistrationRepository
    {
        Task<IEnumerable<VehicleRegistrationDTO>> GetAllAsync(IFiltering filtering, IPaging paging, ISorting sorting);
        Task<VehicleRegistrationDTO> GetAsync(Guid id);
        EntityEntry<VehicleRegistration> Add(VehicleRegistrationDTO entity);
        EntityEntry<VehicleRegistration> Update(VehicleRegistrationDTO entity);
        Task<EntityEntry<VehicleRegistration>> DeleteAsync(Guid id);
        EntityEntry<VehicleRegistration> Delete(VehicleRegistrationDTO entity);
    }
}
