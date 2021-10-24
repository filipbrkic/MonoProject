using AutoMapper;
using MonoProject.Common.Interface;
using MonoProject.Common.Models;
using MonoProject.DAL.Models;
using MonoProject.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MonoProject.Repository
{
    public class VehicleOwnerRepository : IVehicleOwnerRepository
    {
        private readonly IMapper mapper;
        private readonly IGenericRepository genericRepository;

        public VehicleOwnerRepository(IMapper mapper, IGenericRepository genericRepository)
        {
            this.mapper = mapper;
            this.genericRepository = genericRepository;
        }
        public async Task<IEnumerable<VehicleOwnerDTO>> GetAllAsync(IFiltering filtering, IPaging paging, ISorting sorting)
        {
            var result = await genericRepository.GetAllAsync<VehicleOwner>(CreateFilterExpression(filtering.Search, filtering.SearchBy), CreateOrderByExpression(sorting.SortBy), paging.PageSize, paging.Skip, sorting.SortOrder);
            paging.TotalItemsCount = result.Item2;
            return mapper.Map<IEnumerable<VehicleOwnerDTO>>(result.Item1);
        }
        private static Expression<Func<VehicleOwner, bool>> CreateFilterExpression(string search, string searchBy)
        {
            if (!string.IsNullOrEmpty(search))
            {
                return v => searchBy == "FirstName" ?
                v.FirstName.IndexOf(search) > -1 :
                v.LastName.IndexOf(search) > -1;
            }
            return x => x.FirstName.StartsWith(String.Empty);
        }
        private static Expression<Func<VehicleOwner, string>> CreateOrderByExpression(string sortBy)
        {
            if (sortBy == "FirstName" || sortBy == null)
            {
                return v => v.FirstName;
            }
            else
            {
                return v => v.LastName;
            }
        }

        public async Task<int> AddAsync(VehicleOwnerDTO entity)
        {
            entity.Id = Guid.NewGuid();
            return await genericRepository.AddAsync(mapper.Map<VehicleOwner>(entity));
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await genericRepository.DeleteAsync<VehicleOwner>(id);
        }

        public async Task<int> DeleteAsync(VehicleOwnerDTO entity)
        {
            return await genericRepository.DeleteAsync(mapper.Map<VehicleOwner>(entity));
        }

        public async Task<VehicleOwnerDTO> GetAsync(Guid id)
        {
            return mapper.Map<VehicleOwnerDTO>(await genericRepository.GetAsync<VehicleOwner>(id));
        }

        public async Task<int> UpdateAsync(VehicleOwnerDTO entity)
        {
            return await genericRepository.UpdateAsync(mapper.Map<VehicleOwner>(entity));
        }
    }
}
