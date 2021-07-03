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

        public Task<int> AddAsync(VehicleMakeDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(VehicleMakeDTO entity)
        {
            throw new NotImplementedException();
        }


        public Task<VehicleMakeDTO> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(VehicleMakeDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
