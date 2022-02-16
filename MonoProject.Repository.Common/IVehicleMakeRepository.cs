using Microsoft.EntityFrameworkCore.ChangeTracking;
using MonoProject.Common.Interface;
using MonoProject.DAL.Models;
using MonoProject.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonoProject.Repository.Common
{
    public interface IVehicleMakeRepository
    {
        Task<IEnumerable<VehicleMakeDTO>> GetAllAsync(IFiltering filtering, IPaging paging, ISorting sorting);
        Task<VehicleMakeDTO> GetAsync(Guid id);
        EntityEntry<VehicleMake> Add(VehicleMakeDTO entity);
        EntityEntry<VehicleMake> Update(VehicleMakeDTO entity);
        Task<EntityEntry<VehicleMake>> DeleteAsync(Guid id);
        EntityEntry<VehicleMake> Delete(VehicleMakeDTO entity);
    }
}
