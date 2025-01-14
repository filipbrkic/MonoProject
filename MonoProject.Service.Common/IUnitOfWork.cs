﻿using MonoProject.Repository.Common;

namespace MonoProject.Service.Common
{
    public interface IUnitOfWork
    {
        IVehicleMakeRepository VehicleMakeRepository { get; }

        IVehicleModelRepository VehicleModelRepository { get; }

        IVehicleEngineTypeRepository VehicleEngineTypeRepository { get; }

        IVehicleOwnerRepository VehicleOwnerRepository { get; }

        IVehicleRegistrationRepository VehicleRegistrationRepository { get; }

        void SaveChanges();
    }
}
