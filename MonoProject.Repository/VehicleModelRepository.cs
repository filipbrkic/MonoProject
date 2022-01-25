using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        public VehicleModelRepository(IMapper mapper, IGenericRepository genericRepository, VehicleDbContext context)
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

        public EntityEntry<VehicleModel> Add(VehicleModelDTO entity)
        {
            entity.Id = Guid.NewGuid();
            return genericRepository.Add(mapper.Map<VehicleModel>(entity));
        }

        public async Task<EntityEntry<VehicleModel>> DeleteAsync(Guid id)
        {
            return await genericRepository.DeleteAsync<VehicleModel>(id);
        }

        public EntityEntry<VehicleModel> Delete(VehicleModelDTO entity)
        {
            return genericRepository.Delete(mapper.Map<VehicleModel>(entity));
        }

        public async Task<VehicleModelDTO> GetAsync(Guid id)
        {
            return mapper.Map<VehicleModelDTO>(await genericRepository.GetAsync<VehicleModel>(id));
        }

        public EntityEntry<VehicleModel> Update(VehicleModelDTO entity)
        {
            context.ChangeTracker.Clear();
            return genericRepository.Update(mapper.Map<VehicleModel>(entity));
        }
    }
}
