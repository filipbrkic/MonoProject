using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MonoProject.DAL.Data;
using MonoProject.DAL.Models;
using MonoProject.Models;
using MonoProject.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MonoProject.Repository
{
    public class VehicleModelToVehicleOwnerLinkRepository : IVehicleModelToVehicleOwnerLinkRepository
    {
        private readonly IMapper mapper;
        private readonly IGenericRepository genericRepository;
        private readonly VehicleDbContext context;

        public VehicleModelToVehicleOwnerLinkRepository(IMapper mapper, IGenericRepository genericRepository, VehicleDbContext context)
        {
            this.context = context;
            this.mapper = mapper;
            this.genericRepository = genericRepository;
        }

        public async Task<IEnumerable<VehicleModelToVehicleOwnerLinkDTO>> GetAllAsync(Expression<Func<VehicleModelToVehicleOwnerLink, bool>> ownerMatch)
        {
            var test = await genericRepository.GetAllAsync<VehicleModelToVehicleOwnerLink>(ownerMatch);
            return mapper.Map<IEnumerable<VehicleModelToVehicleOwnerLinkDTO>>(await genericRepository.GetAllAsync<VehicleModelToVehicleOwnerLink>(ownerMatch));
        }

        public async Task<VehicleModelToVehicleOwnerLinkDTO> GetAsync(Guid id)
        {
            return mapper.Map<VehicleModelToVehicleOwnerLinkDTO>(await genericRepository.GetAsync<VehicleModelToVehicleOwnerLink>(id));
        }

        public EntityEntry<VehicleModelToVehicleOwnerLink> Add(VehicleModelToVehicleOwnerLinkDTO entity)
        {
            return genericRepository.Add(mapper.Map<VehicleModelToVehicleOwnerLink>(entity));
        }

        public async Task<EntityEntry<VehicleModelToVehicleOwnerLink>> DeleteAsync(Guid id)
        {
            return await genericRepository.DeleteAsync<VehicleModelToVehicleOwnerLink>(id);
        }

        public EntityEntry<VehicleModelToVehicleOwnerLink> Delete(VehicleModelToVehicleOwnerLinkDTO entity)
        {
            return genericRepository.Delete(mapper.Map<VehicleModelToVehicleOwnerLink>(entity));
        }
    }
}
