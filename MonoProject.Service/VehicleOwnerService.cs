using Microsoft.EntityFrameworkCore.ChangeTracking;
using MonoProject.Common.Interface;
using MonoProject.DAL.Models;
using MonoProject.Models;
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

        public async Task<IEnumerable<VehicleOwnerDTO>> GetAllAsync(IFiltering filtering, IPaging paging, ISorting sorting)
        {
            return await unitOfWork.VehicleOwnerRepository.GetAllAsync(filtering, paging, sorting);
        }

        public EntityEntry<VehicleOwner> Add(VehicleOwnerDTO entity)
        {
            var result = unitOfWork.VehicleOwnerRepository.Add(entity);
            unitOfWork.SaveChanges();
            return result;
        }

        public async Task<EntityEntry<VehicleOwner>> DeleteAsync(Guid id)
        {
            var result = await unitOfWork.VehicleOwnerRepository.DeleteAsync(id);
            unitOfWork.SaveChanges();
            return result;
        }

        public EntityEntry<VehicleOwner> Delete(VehicleOwnerDTO entity)
        {
            var result = unitOfWork.VehicleOwnerRepository.Delete(entity);
            unitOfWork.SaveChanges();
            return result;
        }

        public async Task<VehicleOwnerDTO> GetAsync(Guid id)
        {
            return await unitOfWork.VehicleOwnerRepository.GetAsync(id);
        }

        public EntityEntry<VehicleOwner> Update(VehicleOwnerDTO entity)
        {
            var result = unitOfWork.VehicleOwnerRepository.Update(entity);
            unitOfWork.SaveChanges();
            return result;
        }
    }
}
