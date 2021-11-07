using MonoProject.Common.Models;
using System;
using System.Threading.Tasks;

namespace MonoProject.Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> AddVehicleAsync(VehicleOwnerDTO vehicleOwnerDTO, VehicleModelToVehicleOwnerLinkDTO link);
    }
}
