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
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private readonly IMapper mapper;
        private readonly IGenericRepository genericRepository;

        public VehicleModelRepository(IMapper mapper, IGenericRepository genericRepository)
        {
            this.mapper = mapper;
            this.genericRepository = genericRepository;
        }
        public async Task<IEnumerable<VehicleModelDTO>> GetAllAsync(IFiltering filtering, IPaging paging, ISorting sorting)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddAsync(VehicleModelDTO entity)
        {
            entity.Id = Guid.NewGuid();
            return await genericRepository.AddAsync(mapper.Map<VehicleModel>(entity));
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await genericRepository.DeleteAsync<VehicleModel>(id);
        }

        public async Task<int> DeleteAsync(VehicleModelDTO entity)
        {
            return await genericRepository.DeleteAsync(mapper.Map<VehicleModel>(entity));
        }


        public async Task<VehicleModelDTO> GetAsync(Guid id)
        {
            return mapper.Map<VehicleModelDTO>(await genericRepository.GetAsync<VehicleModel>(id));
        }

        public async Task<int> UpdateAsync(VehicleModelDTO entity)
        {
            return await genericRepository.UpdateAsync(mapper.Map<VehicleModel>(entity));
        }
    }
}
