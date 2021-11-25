using AutoMapper;
using MonoProject.Common.Models;
using MonoProject.DAL.Data;
using MonoProject.DAL.Models;
using MonoProject.Repository.Common;
using System;
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

        public async Task<int> AddVehicleOwnerAsync(VehicleOwnerDTO vehicleOwnerDTO, VehicleModelToVehicleOwnerLinkDTO link)
        {
            var addOwner =  await vehicleOwnerRepository.AddAsync(vehicleOwnerDTO);

            var vehicleRegistrationDTO = new VehicleRegistrationDTO() { Id = Guid.NewGuid(), RegistrationNumber = link.RegistrationNumber };
            var addRegistration = await vehicleRegistrationRepository.AddAsync(vehicleRegistrationDTO);

            link.RegistrationId = vehicleRegistrationDTO.Id;

            var addLink = await vehicleModelToVehicleOwnerLinkRepository.AddAsync(link);
            var results = addOwner & addRegistration & addLink;

            return Convert.ToBoolean(results) ? 1 : 0;
        }

        public async Task<int> DeleteVehicleOwnerAsync (Guid id)
        {
            //1) get all vehicleModelToVehicleOwnerLink models (links repository needed)
            Expression<Func<VehicleModelToVehicleOwnerLink, bool>> ownerMatch = m => m.Equals(id);
            var vehicleModelToVehicleOwnerLink = await vehicleModelToVehicleOwnerLinkRepository.GetAllAsync(ownerMatch);

            //2) select all that models registrationIds to list or collection - use linq Select() with lambda function
            var registrationIds = vehicleModelToVehicleOwnerLink.Select(m => m.RegistrationId);

            //3) now you have - ownerId, all registrationIds and all link models that should be deleted


            //4) delete all link models - find bulk delete to not make milion calls to database but actually do it in one call over DbContext (links repository needed)
            var deleteLink = await vehicleModelToVehicleOwnerLinkRepository.DeleteRangeAsync(vehicleModelToVehicleOwnerLink);
            //5) delete all registrations (registration repository need, also bulk delete for registrations)
            Expression<Func<VehicleRegistration, bool>> match = r => registrationIds.Contains(r.Id);
            var deleteOwnerRegistrations = await vehicleRegistrationRepository.BulkDeleteAsync(match);
            
            //6) delete owner over ownerId (owner repostiroy needed)
            var deleteOwner = await vehicleOwnerRepository.DeleteAsync(id);
            return 1 & deleteOwnerRegistrations & deleteOwner; 
        }

        public async Task<int> AddVehicleModelAsync(VehicleModelDTO vehicleModelDTO, VehicleEngineTypeDTO vehicleEngineTypeDTO)
        {
            var addEngineType = await vehicleEngineTypeRepository.AddAsync(vehicleEngineTypeDTO);

            vehicleModelDTO.EngineTypeId = vehicleEngineTypeDTO.Id;
            var addModel = await vehicleModelRepository.AddAsync(vehicleModelDTO);

            return addEngineType & addModel;
        }

        public async Task<int> DeleteVehicleModelAsync(Guid id)
        {
            var getModel = await vehicleModelRepository.GetAsync(id);
            var deleteModel = await vehicleModelRepository.DeleteAsync(id);

            var deleteEngineType = await vehicleEngineTypeRepository.DeleteAsync(getModel.EngineTypeId);

            var results = deleteModel & deleteEngineType;

            return Convert.ToBoolean(results) ? 1 : 0;
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }
    } 
}
