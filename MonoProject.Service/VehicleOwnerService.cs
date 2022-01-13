using MonoProject.Common.Interface;
using MonoProject.Common.Models;
using MonoProject.Repository.Common;
using MonoProject.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonoProject.Service
{
    public class VehicleOwnerService : IVehicleOwnerService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IVehicleOwnerRepository vehicleOwnerRepository;

        public VehicleOwnerService(IUnitOfWork unitOfWork, IVehicleOwnerRepository vehicleOwnerRepository)
        {
            this.unitOfWork = unitOfWork;
            this.vehicleOwnerRepository = vehicleOwnerRepository;
        }

        public async Task<int> AddAsync(VehicleOwnerDTO entity, VehicleModelToVehicleOwnerLinkDTO link)
        {
            return await unitOfWork.AddVehicleModelOwnerAsync(entity, link);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await unitOfWork.DeleteVehicleOwnerAsync(id);
        }

        public async Task<int> DeleteAsync(VehicleOwnerDTO entity)
        {
            return await vehicleOwnerRepository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<VehicleOwnerDTO>> GetAllAsync(IFiltering filtering, IPaging paging, ISorting sorting)
        {
            return await vehicleOwnerRepository.GetAllAsync(filtering, paging, sorting);
        }

        public async Task<VehicleOwnerDTO> GetAsync(Guid id)
        {
            return await vehicleOwnerRepository.GetAsync(id);
        }

        public async Task<int> UpdateAsync(VehicleOwnerDTO entity)
        {
            return await vehicleOwnerRepository.UpdateAsync(entity);
        }
    }
}
