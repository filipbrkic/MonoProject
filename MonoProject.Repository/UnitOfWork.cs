using AutoMapper;
using MonoProject.DAL.Data;
using MonoProject.Repository.Common;
using System;

namespace MonoProject.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VehicleDbContext context;
        private readonly IMapper mapper;
        private readonly IGenericRepository genericRepository;

        public UnitOfWork(VehicleDbContext context, IMapper mapper, IGenericRepository genericRepository)
        {
            this.context = context;
            this.mapper = mapper;
            this.genericRepository = genericRepository;
        }

        private IVehicleModelRepository vehicleModelRepository;
        public IVehicleModelRepository VehicleModelRepository
        {
            get
            {
                if (vehicleModelRepository == null)
                {
                    vehicleModelRepository = new VehicleModelRepository(context, mapper, genericRepository);
                }

                return vehicleModelRepository;
            }
        }

        private IVehicleOwnerRepository vehicleOwnerRepository;
        public IVehicleOwnerRepository VehicleOwnerRepository
        {
            get
            {
                if (vehicleOwnerRepository == null)
                {
                    vehicleOwnerRepository = new VehicleOwnerRepository(context, mapper, genericRepository);
                }

                return vehicleOwnerRepository;
            }
        }

        private IVehicleRegistrationRepository vehicleRegistrationRepository;
        public IVehicleRegistrationRepository VehicleRegistrationRepository
        {
            get
            {
                if (vehicleRegistrationRepository == null)
                {
                    vehicleRegistrationRepository = new VehicleRegistrationRepository(context, mapper, genericRepository);
                }

                return vehicleRegistrationRepository;
            }
        }

        private IVehicleModelToVehicleOwnerLinkRepository vehicleModelToVehicleOwnerLinkRepository;
        public IVehicleModelToVehicleOwnerLinkRepository VehicleModelToVehicleOwnerLinkRepository
        {
            get
            {
                if (vehicleModelToVehicleOwnerLinkRepository == null)
                {
                    vehicleModelToVehicleOwnerLinkRepository = new VehicleModelToVehicleOwnerLinkRepository(context, mapper, genericRepository);
                }

                return vehicleModelToVehicleOwnerLinkRepository;
            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
