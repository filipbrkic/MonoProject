using AutoMapper;
using MonoProject.Common.Interface;
using MonoProject.Common.Models;
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
        public Task<IEnumerable<VehicleModelDTO>> GetAllAsync(ISorting sorting, IFiltering filtering, IPaging paging)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddAsync(VehicleModelDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(VehicleModelDTO entity)
        {
            throw new NotImplementedException();
        }


        public Task<VehicleModelDTO> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(VehicleModelDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
