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
    public class VehicleModelService : IVehicleModelService
    {
        private readonly IUnitOfWork unitOfWork;

        public VehicleModelService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<VehicleModelDTO>> GetAllAsync(IFiltering filtering, IPaging paging, ISorting sorting)
        {
            return await unitOfWork.VehicleModelRepository.GetAllAsync(filtering, paging, sorting);
        }

        public EntityEntry<VehicleModel> Add(VehicleModelDTO entity)
        {
            var result = unitOfWork.VehicleModelRepository.Add(entity);
            unitOfWork.SaveChanges();
            return result;
        }

        public async Task<EntityEntry<VehicleModel>> DeleteAsync(Guid id)
        {
            var result = await unitOfWork.VehicleModelRepository.DeleteAsync(id);
            unitOfWork.SaveChanges();
            return result;
        }

        public EntityEntry<VehicleModel> Delete(VehicleModelDTO entity)
        {
            var result = unitOfWork.VehicleModelRepository.Delete(entity);
            unitOfWork.SaveChanges();
            return result;
        }

        public async Task<VehicleModelDTO> GetAsync(Guid id)
        {
            return await unitOfWork.VehicleModelRepository.GetAsync(id);
        }

        public EntityEntry<VehicleModel> Update(VehicleModelDTO entity)
        {
            var result = unitOfWork.VehicleModelRepository.Update(entity);
            unitOfWork.SaveChanges();
            return result;
        }
    }
}
