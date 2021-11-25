using AutoMapper;
using MonoProject.Common.Interface;
using MonoProject.Common.Models;
using MonoProject.DAL.Data;
using MonoProject.DAL.Models;
using MonoProject.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MonoProject.Repository
{
    public class VehicleRegistrationRepository : IVehicleRegistrationRepository
    {
        private readonly IMapper mapper;
        private readonly IGenericRepository genericRepository;
        private readonly VehicleDbContext context;

        public VehicleRegistrationRepository(VehicleDbContext context, IMapper mapper, IGenericRepository genericRepository)
        {
            this.mapper = mapper;
            this.genericRepository = genericRepository;
            this.context = context;
        }

        public async Task<IEnumerable<VehicleRegistrationDTO>> GetAllAsync(IFiltering filtering, IPaging paging, ISorting sorting)
        {
            var result = await genericRepository.GetAllAsync<VehicleRegistration>(CreateFilterExpression(filtering.Search, filtering.SearchBy), CreateOrderByExpression(sorting.SortBy), paging.PageSize, paging.Skip, sorting.SortOrder);
            paging.TotalItemsCount = result.Item2;
            return mapper.Map<IEnumerable<VehicleRegistrationDTO>>(result.Item1);
        }
        private static Expression<Func<VehicleRegistration, bool>> CreateFilterExpression(string search, string searchBy)
        {
            if (!string.IsNullOrEmpty(search))
            {
                return v => searchBy == "RegistrationNumber" ?
                v.RegistrationNumber.IndexOf(search) > -1 :
                v.Id.ToString().IndexOf(search) > -1;
            }
            return x => x.RegistrationNumber.StartsWith(String.Empty);
        }
        private static Expression<Func<VehicleRegistration, string>> CreateOrderByExpression(string sortBy)
        {
            if (sortBy == "RegistrationNumber" || sortBy == null)
            {
                return v => v.RegistrationNumber;
            }
            else
            {
                return v => v.Id.ToString();
            }
        }

        public async Task<int> AddAsync(VehicleRegistrationDTO entity)
        {
            return await genericRepository.AddAsync(mapper.Map<VehicleRegistration>(entity));
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await genericRepository.DeleteAsync<VehicleRegistration>(id);
        }

        public async Task<int> DeleteAsync(VehicleRegistrationDTO entity)
        {
            return await genericRepository.DeleteAsync(mapper.Map<VehicleRegistration>(entity));
        }
        
        public async Task<int> BulkDeleteAsync(Expression<Func<VehicleRegistration, bool>> match)
        {
            return await genericRepository.BulkDeleteAsync<VehicleRegistration>(match);
        }

        public async Task<VehicleRegistrationDTO> GetAsync(Guid id)
        {
            return mapper.Map<VehicleRegistrationDTO>(await genericRepository.GetAsync<VehicleRegistration>(id));
        }

        public async Task<int> UpdateAsync(VehicleRegistrationDTO entity)
        {
            context.ChangeTracker.Clear();
            return await genericRepository.UpdateAsync(mapper.Map<VehicleRegistration>(entity));
        }
    }
}
