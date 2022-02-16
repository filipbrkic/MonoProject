using Microsoft.EntityFrameworkCore.ChangeTracking;
using MonoProject.DAL.Models;
using MonoProject.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MonoProject.Repository.Common
{
    public interface IVehicleModelToVehicleOwnerLinkRepository
    {
        Task<IEnumerable<VehicleModelToVehicleOwnerLinkDTO>> GetAllAsync(Expression<Func<VehicleModelToVehicleOwnerLink, bool>> ownerMatch);
        Task<VehicleModelToVehicleOwnerLinkDTO> GetAsync(Guid id);
        EntityEntry<VehicleModelToVehicleOwnerLink> Add(VehicleModelToVehicleOwnerLinkDTO entity);
        Task<EntityEntry<VehicleModelToVehicleOwnerLink>> DeleteAsync(Guid id);
        EntityEntry<VehicleModelToVehicleOwnerLink> Delete(VehicleModelToVehicleOwnerLinkDTO entity);
    }
}
