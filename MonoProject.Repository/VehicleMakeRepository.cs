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
        public VehicleMakeRepository(IMapper mapper, IGenericRepository genericRepository)
        {

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

        public Task<IEnumerable<VehicleMakeDTO>> GetAllAsync(ISorting sorting, IFiltering filtering, IPaging paging)
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
