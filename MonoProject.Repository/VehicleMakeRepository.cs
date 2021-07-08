using AutoMapper;
using MonoProject.Common.Interface;
using MonoProject.Common.Models;
using MonoProject.DAL.Models;
using MonoProject.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProject.Repository
{
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        private readonly IMapper mapper;
        private readonly IGenericRepository genericRepository;

        public VehicleMakeRepository(IMapper mapper, IGenericRepository genericRepository)
        {
            this.mapper = mapper;
            this.genericRepository = genericRepository;
        }
        public Task<IEnumerable<VehicleMakeDTO>> GetAllAsync(ISorting sorting, IFiltering filtering, IPaging paging)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddAsync(VehicleMakeDTO entity)
        {
            entity.Id = Guid.NewGuid();
            return await genericRepository.AddAsync(mapper.Map<VehicleMake>(entity));
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await genericRepository.DeleteAsync<VehicleMake>(id);
        }

        public async Task<int> DeleteAsync(VehicleMakeDTO entity)
        {
            return await genericRepository.DeleteAsync(mapper.Map<VehicleMake>(entity));
        }


        public async Task<VehicleMakeDTO> GetAsync(Guid id)
        {
            return mapper.Map<VehicleMakeDTO>(await genericRepository.GetAsync<VehicleMake>(id));
        }

        public async Task<int> UpdateAsync(VehicleMakeDTO entity)
        {
            return await genericRepository.UpdateAsync(mapper.Map<VehicleMake>(entity));
        }
    }
}
