using MonoProject.Common.Interface;
using MonoProject.Common.Models;
using MonoProject.Repository.Common;
using MonoProject.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProject.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly IVehicleMakeRepository vehicleMakeRepository;

        public VehicleMakeService(IVehicleMakeRepository vehicleMakeRepository)
        {
            this.vehicleMakeRepository = vehicleMakeRepository;
        }
        public async Task<IEnumerable<VehicleMakeDTO>> GetAllAsync(IFiltering filtering, IPaging paging, ISorting sorting)
        {
            return await vehicleMakeRepository.GetAllAsync(filtering, paging, sorting);
        }

        public async Task<int> AddAsync(VehicleMakeDTO entity)
        {
            return await vehicleMakeRepository.AddAsync(entity);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await vehicleMakeRepository.DeleteAsync(id);
        }

        public async Task<int> DeleteAsync(VehicleMakeDTO entity)
        {
            return await vehicleMakeRepository.DeleteAsync(entity);
        }


        public async Task<VehicleMakeDTO> GetAsync(Guid id)
        {
            return await vehicleMakeRepository.GetAsync(id);
        }

        public async Task<int> UpdateAsync(VehicleMakeDTO entity)
        {
            return await vehicleMakeRepository.UpdateAsync(entity);
        }
    }
}
