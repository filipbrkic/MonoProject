using AutoMapper;
using MonoProject.Common.Models;
using MonoProject.DAL.Data;
using MonoProject.DAL.Models;
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

        public VehicleModelToVehicleOwnerLinkRepository(VehicleDbContext context, IMapper mapper, IGenericRepository genericRepository)
        {
            this.context = context;
            this.mapper = mapper;
            this.genericRepository = genericRepository;
        }

        public async Task<IEnumerable<VehicleModelToVehicleOwnerLinkDTO>> GetAllAsync(Expression<Func<VehicleModelToVehicleOwnerLink, bool>> ownerMatch)
        {
            return mapper.Map<IEnumerable<VehicleModelToVehicleOwnerLinkDTO>>(await genericRepository.GetAllAsync<VehicleModelToVehicleOwnerLink>(ownerMatch));
        }

        public async Task<VehicleModelToVehicleOwnerLinkDTO> GetAsync(Guid id)
        {
            return mapper.Map<VehicleModelToVehicleOwnerLinkDTO>(await genericRepository.GetAsync<VehicleModelToVehicleOwnerLink>(id));
        }

        public async Task<int> AddAsync(VehicleModelToVehicleOwnerLinkDTO entity)
        {
            return await genericRepository.AddAsync(mapper.Map<VehicleModelToVehicleOwnerLink>(entity));
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await genericRepository.DeleteAsync<VehicleModelToVehicleOwnerLink>(id);
        }

        public async Task<int> DeleteAsync(VehicleModelToVehicleOwnerLinkDTO entity)
        {
            return await genericRepository.DeleteAsync(mapper.Map<VehicleModelToVehicleOwnerLink>(entity));
        }

        public async Task<int> DeleteRangeAsync(IEnumerable<VehicleModelToVehicleOwnerLinkDTO> entity)
        {
            return await genericRepository.DeleteRangeAsync<VehicleModelToVehicleOwnerLinkDTO>(entity);
        }
    }
}
