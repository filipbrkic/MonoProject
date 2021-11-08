using AutoMapper;
using MonoProject.Common.Models;
using MonoProject.DAL.Data;
using MonoProject.Repository.Common;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MonoProject.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VehicleDbContext context;
        private readonly IMapper mapper;
        private readonly IGenericRepository genericRepository;
        private readonly IVehicleModelRepository vehicleModelRepository;
        private readonly IVehicleOwnerRepository vehicleOwnerRepository;
        private readonly IVehicleRegistrationRepository vehicleRegistrationRepository;
        private readonly IVehicleModelToVehicleOwnerLinkRepository vehicleModelToVehicleOwnerLinkRepository;

        public UnitOfWork(VehicleDbContext context,
            IMapper mapper,
            IGenericRepository genericRepository,
            
            IVehicleModelRepository vehicleModelRepository,
            IVehicleOwnerRepository vehicleOwnerRepository,
            IVehicleRegistrationRepository vehicleRegistrationRepository,
            IVehicleModelToVehicleOwnerLinkRepository vehicleModelToVehicleOwnerLinkRepository
            )
        {
            this.context = context;
            this.mapper = mapper;
            this.genericRepository = genericRepository;
            this.vehicleModelRepository = vehicleModelRepository;
            this.vehicleOwnerRepository = vehicleOwnerRepository;
            this.vehicleRegistrationRepository = vehicleRegistrationRepository;
            this.vehicleModelToVehicleOwnerLinkRepository = vehicleModelToVehicleOwnerLinkRepository;
        }

        public async Task<int> AddVehicleAsync(VehicleOwnerDTO vehicleOwnerDTO, VehicleModelToVehicleOwnerLinkDTO link)
        {
            var addOwner =  await vehicleOwnerRepository.AddAsync(vehicleOwnerDTO);

            var vehicleRegistrationDTO = new VehicleRegistrationDTO() { Id = Guid.NewGuid(), RegistrationNumber = link.RegistrationNumber };
            var addRegistration = await vehicleRegistrationRepository.AddAsync(vehicleRegistrationDTO);

            link.RegistrationId = vehicleRegistrationDTO.Id;
            link.ModelId = Guid.Parse("669e4649-3651-4b2f-a645-8c46d351b99d");        //FOR TESTING WITH POSTMAN
            var addLink = await vehicleModelToVehicleOwnerLinkRepository.AddAsync(link);
            var results = addOwner & addRegistration & addLink;

            return Convert.ToBoolean(results) ? 1 : 0;
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        } 
    } 
}
