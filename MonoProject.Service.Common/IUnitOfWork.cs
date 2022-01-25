using MonoProject.Repository.Common;
using System;

namespace MonoProject.Service.Common
{
    public interface IUnitOfWork
    {
        public IVehicleMakeRepository VehicleMakeRepository { get; }

        public IVehicleModelRepository VehicleModelRepository { get; }

        public IVehicleEngineTypeRepository VehicleEngineTypeRepository { get; }

        public IVehicleOwnerRepository VehicleOwnerRepository { get; }

        public IVehicleRegistrationRepository VehicleRegistrationRepository { get; }

        public void SaveChanges();
    }
}
