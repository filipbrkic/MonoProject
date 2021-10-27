using System;

namespace MonoProject.Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IVehicleModelRepository VehicleModelRepository { get; }
        IVehicleOwnerRepository VehicleOwnerRepository { get; }
        IVehicleRegistrationRepository VehicleRegistrationRepository { get; }
        IVehicleModelToVehicleOwnerLinkRepository VehicleModelToVehicleOwnerLinkRepository { get; }

        void SaveChanges();
    }
}
