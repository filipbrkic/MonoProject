using MonoProject.Common.Models;
using System;
using System.Threading.Tasks;

namespace MonoProject.Repository.Common
{
    public interface IVehicleModelToVehicleOwnerLinkRepository
    {
        Task<int> AddAsync(VehicleModelToVehicleOwnerLinkDTO entity);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(VehicleModelToVehicleOwnerLinkDTO entity);
    }
}
