using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MonoProject.Common.Interface;
using MonoProject.Common.Models;
using MonoProject.DAL.Models;
using MonoProject.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MonoProject.Repository
{
    public class VehicleEngineTypeRepository : IVehicleEngineTypeRepository
    {
        private readonly IMapper mapper;
        private readonly IGenericRepository genericRepository;

        public VehicleEngineTypeRepository(IMapper mapper, IGenericRepository genericRepository)
        {
            this.mapper = mapper;
            this.genericRepository = genericRepository;
        }

        public async Task<IEnumerable<VehicleEngineTypeDTO>> GetAllAsync()
        {
            var result = await genericRepository.GetAllAsync<VehicleEngineType>(x => true);
            return mapper.Map<IEnumerable<VehicleEngineTypeDTO>>(result);
        }

        public async Task<VehicleEngineTypeDTO> GetAsync(Guid id)
        {
            return mapper.Map<VehicleEngineTypeDTO>(await genericRepository.GetAsync<VehicleEngineType>(id));
        }

        public EntityEntry<VehicleEngineType> Add(VehicleEngineTypeDTO entity)
        {
            entity.Id = Guid.NewGuid();
            return genericRepository.Add(mapper.Map<VehicleEngineType>(entity));
        }

        public async Task<EntityEntry<VehicleEngineType>> DeleteAsync(Guid id)
        {
            return await genericRepository.DeleteAsync<VehicleEngineType>(id);
        }

        public EntityEntry<VehicleEngineType> DeleteAsync(VehicleEngineTypeDTO entity)
        {
            return genericRepository.Delete(mapper.Map<VehicleEngineType>(entity));
        }
    }
}
