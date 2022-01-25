using Microsoft.EntityFrameworkCore.ChangeTracking;
using MonoProject.Common.Interface;
using MonoProject.Common.Models;
using MonoProject.DAL.Models;
using MonoProject.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonoProject.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly IUnitOfWork unitOfWork;

        public VehicleMakeService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<VehicleMakeDTO>> GetAllAsync(IFiltering filtering, IPaging paging, ISorting sorting)
        {
            return await unitOfWork.VehicleMakeRepository.GetAllAsync(filtering, paging, sorting);
        }

        public EntityEntry<VehicleMake> Add(VehicleMakeDTO entity)
        {
            var result = unitOfWork.VehicleMakeRepository.Add(entity);
            unitOfWork.SaveChanges();
            return result;

        }

        public async Task<EntityEntry<VehicleMake>> DeleteAsync(Guid id)
        {
            var result = await unitOfWork.VehicleMakeRepository.DeleteAsync(id);
            unitOfWork.SaveChanges();
            return result;
        }

        public EntityEntry<VehicleMake> Delete(VehicleMakeDTO entity)
        {
            var result = unitOfWork.VehicleMakeRepository.Delete(entity);
            unitOfWork.SaveChanges();
            return result;
        }

        public async Task<VehicleMakeDTO> GetAsync(Guid id)
        {
            return await unitOfWork.VehicleMakeRepository.GetAsync(id);
        }

        public EntityEntry<VehicleMake> Update(VehicleMakeDTO entity)
        {
            var result = unitOfWork.VehicleMakeRepository.Update(entity);
            unitOfWork.SaveChanges();
            return result;
        }
    }
}
