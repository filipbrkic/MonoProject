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
