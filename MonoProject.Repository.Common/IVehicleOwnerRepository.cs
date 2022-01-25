using Microsoft.EntityFrameworkCore.ChangeTracking;
using MonoProject.Common.Interface;
using MonoProject.Common.Models;
using MonoProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonoProject.Repository.Common
{
    public interface IVehicleOwnerRepository
    {
        Task<IEnumerable<VehicleOwnerDTO>> GetAllAsync(IFiltering filtering, IPaging paging, ISorting sorting);
        Task<VehicleOwnerDTO> GetAsync(Guid id);
        EntityEntry<VehicleOwner> Add(VehicleOwnerDTO entity);
        EntityEntry<VehicleOwner> Update(VehicleOwnerDTO entity);
        Task<EntityEntry<VehicleOwner>> DeleteAsync(Guid id);
        EntityEntry<VehicleOwner> Delete(VehicleOwnerDTO entity);
    }
}
