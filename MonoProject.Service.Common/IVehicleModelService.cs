using Microsoft.EntityFrameworkCore.ChangeTracking;
using MonoProject.Common.Interface;
using MonoProject.Common.Models;
using MonoProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonoProject.Service.Common
{
    public interface IVehicleModelService
    {
        Task<IEnumerable<VehicleModelDTO>> GetAllAsync(IFiltering filtering, IPaging paging, ISorting sorting);
        EntityEntry<VehicleModel> Add(VehicleModelDTO entity);
        Task<VehicleModelDTO> GetAsync(Guid id);
        EntityEntry<VehicleModel> Update(VehicleModelDTO entity);
        Task<EntityEntry<VehicleModel>> DeleteAsync(Guid id);
        EntityEntry<VehicleModel> Delete(VehicleModelDTO entity);
    }
}
