using MonoProject.Common.Interface;
using MonoProject.Common.Models;
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
        private readonly IVehicleMakeService vehicleMakeService;

        public VehicleMakeService(IVehicleMakeService vehicleMakeService)
        {
            this.vehicleMakeService = vehicleMakeService;
        }
        public async Task<IEnumerable<VehicleMakeDTO>> GetAllAsync(IFiltering filtering, IPaging paging, ISorting sorting)
        {
            return await vehicleMakeService.GetAllAsync(filtering, paging, sorting);
        }

        public async Task<int> AddAsync(VehicleMakeDTO entity)
        {
            return await vehicleMakeService.AddAsync(entity);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await vehicleMakeService.DeleteAsync(id);
        }

        public async Task<int> DeleteAsync(VehicleMakeDTO entity)
        {
            return await vehicleMakeService.DeleteAsync(entity);
        }


        public async Task<VehicleMakeDTO> GetAsync(Guid id)
        {
            return await vehicleMakeService.GetAsync(id);
        }

        public async Task<int> UpdateAsync(VehicleMakeDTO entity)
        {
            return await vehicleMakeService.UpdateAsync(entity);
        }
    }
}
