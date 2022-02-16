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
    public class VehicleRegistrationService : IVehicleRegistrationService
    {
        private readonly IUnitOfWork unitOfWork;

        public VehicleRegistrationService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<VehicleRegistrationDTO>> GetAllAsync(IFiltering filtering, IPaging paging, ISorting sorting)
        {
            return await unitOfWork.VehicleRegistrationRepository.GetAllAsync(filtering, paging, sorting);
        }

        public EntityEntry<VehicleRegistration> Add(VehicleRegistrationDTO entity)
        {
            var result = unitOfWork.VehicleRegistrationRepository.Add(entity);
            unitOfWork.SaveChanges();
            return result;
        }

        public async Task<EntityEntry<VehicleRegistration>> DeleteAsync(Guid id)
        {
            var result = await unitOfWork.VehicleRegistrationRepository.DeleteAsync(id);
            unitOfWork.SaveChanges();
            return result;
        }

        public EntityEntry<VehicleRegistration> Delete(VehicleRegistrationDTO entity)
        {
            var result = unitOfWork.VehicleRegistrationRepository.Delete(entity);
            unitOfWork.SaveChanges();
            return result;
        }

        public async Task<VehicleRegistrationDTO> GetAsync(Guid id)
        {
            return await unitOfWork.VehicleRegistrationRepository.GetAsync(id);
        }

        public EntityEntry<VehicleRegistration> Update(VehicleRegistrationDTO entity)
        {
            var result = unitOfWork.VehicleRegistrationRepository.Update(entity);
            unitOfWork.SaveChanges();
            return result;
        }
    }
}
