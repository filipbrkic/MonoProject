using AutoMapper;
using MonoProject.Common.Models;
using MonoProject.DAL.Data;
using MonoProject.DAL.Models;
using MonoProject.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MonoProject.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VehicleDbContext context;

        private readonly IVehicleEngineTypeRepository vehicleEngineTypeRepository;
        private readonly IVehicleModelRepository vehicleModelRepository;
        private readonly IVehicleOwnerRepository vehicleOwnerRepository;
        private readonly IVehicleRegistrationRepository vehicleRegistrationRepository;
        private readonly IVehicleModelToVehicleOwnerLinkRepository vehicleModelToVehicleOwnerLinkRepository;

        public UnitOfWork(VehicleDbContext context,
            
            IVehicleEngineTypeRepository vehicleEngineTypeRepository,
            IVehicleModelRepository vehicleModelRepository,
            IVehicleOwnerRepository vehicleOwnerRepository,
            IVehicleRegistrationRepository vehicleRegistrationRepository,
            IVehicleModelToVehicleOwnerLinkRepository vehicleModelToVehicleOwnerLinkRepository
            )
        {
            this.context = context;

            this.vehicleEngineTypeRepository = vehicleEngineTypeRepository;
            this.vehicleModelRepository = vehicleModelRepository;
            this.vehicleOwnerRepository = vehicleOwnerRepository;
            this.vehicleRegistrationRepository = vehicleRegistrationRepository;
            this.vehicleModelToVehicleOwnerLinkRepository = vehicleModelToVehicleOwnerLinkRepository;
        }

        public async Task<int> AddVehicleModelOwnerAsync (VehicleOwnerDTO vehicleOwnerDTO, VehicleModelToVehicleOwnerLinkDTO link)
        {
            var addOwner =  await vehicleOwnerRepository.AddAsync(vehicleOwnerDTO);

            var vehicleRegistrationDTO = new VehicleRegistrationDTO() { Id = Guid.NewGuid(), RegistrationNumber = link.RegistrationNumber };
            var addRegistration = await vehicleRegistrationRepository.AddAsync(vehicleRegistrationDTO);

            var vehicleModelDTO = new VehicleModelDTO() { Id = Guid.NewGuid(), Name = link.Name, Abrv = link.Abrv, MakeId = link.MakeId, EngineTypeId = link.EngineTypeId };
            var addModel = await vehicleModelRepository.AddAsync(vehicleModelDTO);

            link.OwnerId = vehicleOwnerDTO.Id;
            link.ModelId = vehicleModelDTO.Id;
            link.RegistrationId = vehicleRegistrationDTO.Id;
            link.MakeId = vehicleModelDTO.MakeId;
            link.EngineTypeId = vehicleModelDTO.EngineTypeId;

            var addLink = await vehicleModelToVehicleOwnerLinkRepository.AddAsync(link);

            var results = addOwner & addRegistration & addLink & addModel;
            return results;
        }

        public async Task<int> DeleteVehicleOwnerAsync (Guid id)
        {
            Expression<Func<VehicleModelToVehicleOwnerLink, bool>> ownerMatch = m => m.OwnerId.Equals(id);

            var vehicleModelToVehicleOwnerLink = await vehicleModelToVehicleOwnerLinkRepository.GetAllAsync(ownerMatch);

            var registrationIds = vehicleModelToVehicleOwnerLink.Select(m => m.RegistrationId);



            var deleteLink = await vehicleModelToVehicleOwnerLinkRepository.DeleteRangeAsync(vehicleModelToVehicleOwnerLink);

            Expression<Func<VehicleRegistration, bool>> match = r => registrationIds.Contains(r.Id);
            var deleteOwnerRegistrations = await vehicleRegistrationRepository.BulkDeleteAsync(match);
            
            var deleteOwner = await vehicleOwnerRepository.DeleteAsync(id);

            var results = deleteOwnerRegistrations & deleteLink & deleteOwner;
            return results; 
        }

        public async Task<int> DeleteVehicleModelAsync(Guid id)
        {
            var getModel = await vehicleModelRepository.GetAsync(id);
            var deleteModel = await vehicleModelRepository.DeleteAsync(id);
            var deleteEngineType = await vehicleEngineTypeRepository.DeleteAsync(getModel.EngineTypeId);

            var results = deleteModel & deleteEngineType;
            return results;
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }
    } 
}
