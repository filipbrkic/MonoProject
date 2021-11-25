using MonoProject.Common.Models;
using System;
using System.Threading.Tasks;

namespace MonoProject.Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> AddVehicleOwnerAsync(VehicleOwnerDTO vehicleOwnerDTO, VehicleModelToVehicleOwnerLinkDTO link);
        Task<int> AddVehicleModelAsync(VehicleModelDTO vehicleModelDTO, VehicleEngineTypeDTO vehicleEngineTypeDTO);
        Task<int> DeleteVehicleModelAsync(Guid id);
        Task<int> DeleteVehicleOwnerAsync(Guid id);
    }
}
