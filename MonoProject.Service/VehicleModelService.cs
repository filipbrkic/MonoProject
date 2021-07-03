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
    public class VehicleModelService : IVehicleModelService
    {
        private readonly IVehicleModelService vehicleModelService;

        public VehicleModelService(IVehicleModelService vehicleModelService)
        {
            this.vehicleModelService = vehicleModelService;
        }
        public async Task<IEnumerable<VehicleModelDTO>> GetAllAsync(IFiltering filtering, IPaging paging, ISorting sorting)
        {
            return await vehicleModelService.GetAllAsync(filtering, paging, sorting);
        }

        public async Task<int> AddAsync(VehicleModelDTO entity)
        {
            return await vehicleModelService.AddAsync(entity);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await vehicleModelService.DeleteAsync(id);
        }

        public async Task<int> DeleteAsync(VehicleModelDTO entity)
        {
            return await vehicleModelService.DeleteAsync(entity);
        }


        public async Task<VehicleModelDTO> GetAsync(Guid id)
        {
            return await vehicleModelService.GetAsync(id);
        }

        public async Task<int> UpdateAsync(VehicleModelDTO entity)
        {
            return await vehicleModelService.UpdateAsync(entity);
        }
    }
}
