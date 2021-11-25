using MonoProject.Common.Models;
using MonoProject.DAL.Models;
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
        Task<int> AddAsync(VehicleModelToVehicleOwnerLinkDTO entity);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(VehicleModelToVehicleOwnerLinkDTO entity);
        Task<int> DeleteRangeAsync(IEnumerable<VehicleModelToVehicleOwnerLinkDTO> entity);
    }
}
