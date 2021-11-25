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
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private readonly IMapper mapper;
        private readonly IGenericRepository genericRepository;
        private readonly VehicleDbContext context;

        public VehicleModelRepository(VehicleDbContext context, IMapper mapper, IGenericRepository genericRepository)
        {
            this.mapper = mapper;
            this.genericRepository = genericRepository;
            this.context = context;
        }

        public async Task<IEnumerable<VehicleModelDTO>> GetAllAsync(IFiltering filtering, IPaging paging, ISorting sorting)
        {
            var result = await genericRepository.GetAllAsync<VehicleModel>(CreateFilterExpression(filtering.Search, filtering.SearchBy), CreateOrderByExpression(sorting.SortBy), paging.PageSize, paging.Skip, sorting.SortOrder);
            paging.TotalItemsCount = result.Item2;
            return mapper.Map<IEnumerable<VehicleModelDTO>>(result.Item1);
        }
        private static Expression<Func<VehicleModel, bool>> CreateFilterExpression(string search, string searchBy)
        {
            if (!string.IsNullOrEmpty(search))
            {
                return v => searchBy == "Name" ?
                v.Name.IndexOf(search) > -1 :
                v.Abrv.IndexOf(search) > -1;
            }
            return x => x.Name.StartsWith(String.Empty);
        }
        private static Expression<Func<VehicleModel, string>> CreateOrderByExpression(string sortBy)
        {
            if (sortBy == "Name" || sortBy == null)
            {
                return v => v.Name;
            }
            else
            {
                return v => v.Abrv;
            }
        }

        public async Task<int> AddAsync(VehicleModelDTO entity)
        {
            return await genericRepository.AddAsync(mapper.Map<VehicleModel>(entity));
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await genericRepository.DeleteAsync<VehicleModel>(id);
        }

        public async Task<int> DeleteAsync(VehicleModelDTO entity)
        {
            return await genericRepository.DeleteAsync(mapper.Map<VehicleModel>(entity));
        }


        public async Task<VehicleModelDTO> GetAsync(Guid id)
        {
            return mapper.Map<VehicleModelDTO>(await genericRepository.GetAsync<VehicleModel>(id));
        }

        public async Task<int> UpdateAsync(VehicleModelDTO entity)
        {
            context.ChangeTracker.Clear();
            return await genericRepository.UpdateAsync(mapper.Map<VehicleModel>(entity));
        }
    }
}
