using MonoProject.DAL.Data;
using MonoProject.Repository.Common;
using MonoProject.Service.Common;
using System;

namespace MonoProject.Service
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VehicleDbContext context;
        private readonly IVehicleMakeRepository vehicleMakeRepository;
        private readonly IVehicleModelRepository vehicleModelRepository;
        private readonly IVehicleEngineTypeRepository vehicleEngineTypeRepository;
        private readonly IVehicleOwnerRepository vehicleOwnerRepository;
        private readonly IVehicleRegistrationRepository vehicleRegistrationRepository;

        public UnitOfWork(VehicleDbContext context, IVehicleMakeRepository vehicleMakeRepository, IVehicleModelRepository vehicleModelRepository, IVehicleEngineTypeRepository vehicleEngineTypeRepository,
            IVehicleOwnerRepository vehicleOwnerRepository, IVehicleRegistrationRepository vehicleRegistrationRepository)
        {
            this.context = context;
            this.vehicleMakeRepository = vehicleMakeRepository;
            this.vehicleModelRepository = vehicleModelRepository;
            this.vehicleEngineTypeRepository = vehicleEngineTypeRepository;
            this.vehicleOwnerRepository = vehicleOwnerRepository;
            this.vehicleRegistrationRepository = vehicleRegistrationRepository;
        }

        public IVehicleMakeRepository VehicleMakeRepository
        {
            get
            {
                return vehicleMakeRepository;
            }
        }

        public IVehicleModelRepository VehicleModelRepository
        {
            get
            {
                return vehicleModelRepository;
            }
        }

        public IVehicleEngineTypeRepository VehicleEngineTypeRepository
        {
            get
            {
                return vehicleEngineTypeRepository;
            }
        }

        public IVehicleOwnerRepository VehicleOwnerRepository
        {
            get
            {
                return vehicleOwnerRepository;
            }
        }

        public IVehicleRegistrationRepository VehicleRegistrationRepository
        {
            get
            {
                return vehicleRegistrationRepository;
            }
        }

        public void SaveChanges()
        {
           context.SaveChanges();
        }

    }
}
