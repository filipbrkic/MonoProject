using Microsoft.EntityFrameworkCore.ChangeTracking;
using MonoProject.Common.Interface;
using MonoProject.Common.Models;
using MonoProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonoProject.Service.Common
{
    public interface IVehicleOwnerService
    {
        Task<IEnumerable<VehicleOwnerDTO>> GetAllAsync(IFiltering filtering, IPaging paging, ISorting sorting);
        EntityEntry<VehicleOwner> Add(VehicleOwnerDTO entity);
        Task<VehicleOwnerDTO> GetAsync(Guid id);
        EntityEntry<VehicleOwner> Update(VehicleOwnerDTO entity);
        Task<EntityEntry<VehicleOwner>> DeleteAsync(Guid id);
        EntityEntry<VehicleOwner> Delete(VehicleOwnerDTO entity);
    }
}
