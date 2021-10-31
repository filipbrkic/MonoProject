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

        public VehicleOwnerService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> AddAsync(VehicleOwnerDTO entity, VehicleModelToVehicleOwnerLinkDTO link)
        {
            await unitOfWork.VehicleOwnerRepository.AddAsync(entity);
            return await unitOfWork.VehicleModelToVehicleOwnerLinkRepository.AddAsync(link);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await unitOfWork.VehicleOwnerRepository.DeleteAsync(id);
        }

        public async Task<int> DeleteAsync(VehicleOwnerDTO entity)
        {
            return await unitOfWork.VehicleOwnerRepository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<VehicleOwnerDTO>> GetAllAsync(IFiltering filtering, IPaging paging, ISorting sorting)
        {
            return await unitOfWork.VehicleOwnerRepository.GetAllAsync(filtering, paging, sorting);
        }

        public async Task<VehicleOwnerDTO> GetAsync(Guid id)
        {
            return await unitOfWork.VehicleOwnerRepository.GetAsync(id);
        }

        public async Task<int> UpdateAsync(VehicleOwnerDTO entity)
        {
            return await unitOfWork.VehicleOwnerRepository.UpdateAsync(entity);
        }
    }
}
