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
        public Task<IEnumerable<VehicleMakeDTO>> GetAllAsync(ISorting sorting, IFiltering filtering, IPaging paging)
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
