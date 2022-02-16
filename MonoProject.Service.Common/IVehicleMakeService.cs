using Microsoft.EntityFrameworkCore.ChangeTracking;
using MonoProject.Common.Interface;
using MonoProject.DAL.Models;
using MonoProject.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonoProject.Service.Common
{
    public interface IVehicleMakeService
    {
        Task<IEnumerable<VehicleMakeDTO>> GetAllAsync(IFiltering filtering, IPaging paging, ISorting sorting);
        EntityEntry<VehicleMake> Add(VehicleMakeDTO entity);
        Task<VehicleMakeDTO> GetAsync(Guid id);
        EntityEntry<VehicleMake> Update(VehicleMakeDTO entity);
        Task<EntityEntry<VehicleMake>> DeleteAsync(Guid id);
        EntityEntry<VehicleMake> Delete(VehicleMakeDTO entity);
    }
}
