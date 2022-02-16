using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MonoProject.Common.Interface;
using MonoProject.DAL.Data;
using MonoProject.DAL.Models;
using MonoProject.Models;
using MonoProject.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MonoProject.Repository
{
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        private readonly IMapper mapper;
        private readonly IGenericRepository genericRepository;
        private readonly VehicleDbContext context;

        public VehicleMakeRepository(IMapper mapper, IGenericRepository genericRepository, VehicleDbContext context)
        {
            this.mapper = mapper;
            this.genericRepository = genericRepository;
            this.context = context;
        }
        public async Task<IEnumerable<VehicleMakeDTO>> GetAllAsync(IFiltering filtering, IPaging paging, ISorting sorting)
        {
            var result = await genericRepository.GetAllAsync<VehicleMake>(CreateFilterExpression(filtering.Search, filtering.SearchBy), CreateOrderByExpression(sorting.SortBy), paging.PageSize, paging.Skip, sorting.SortOrder);
            paging.TotalItemsCount = result.Item2;
            return mapper.Map<IEnumerable<VehicleMakeDTO>>(result.Item1);
        }
        private static Expression<Func<VehicleMake, bool>> CreateFilterExpression(string search, string searchBy)
        {
            if (!string.IsNullOrEmpty(search))
            {
                return v => searchBy == "Name" ?
                v.Name.IndexOf(search) > -1 :
                v.Abrv.IndexOf(search) > -1;
            }
            return x => x.Name.StartsWith(String.Empty);
        }
        private static Expression<Func<VehicleMake, string>> CreateOrderByExpression(string sortBy)
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

        public EntityEntry<VehicleMake> Add(VehicleMakeDTO entity)
        {
            entity.Id = Guid.NewGuid();
            return genericRepository.Add(mapper.Map<VehicleMake>(entity));
        }

        public async Task<EntityEntry<VehicleMake>> DeleteAsync(Guid id)
        {
            return await genericRepository.DeleteAsync<VehicleMake>(id);
        }

        public EntityEntry<VehicleMake> Delete(VehicleMakeDTO entity)
        {
            return genericRepository.Delete(mapper.Map<VehicleMake>(entity));
        }

        public async Task<VehicleMakeDTO> GetAsync(Guid id)
        {
            return mapper.Map<VehicleMakeDTO>(await genericRepository.GetAsync<VehicleMake>(id));
        }

        public EntityEntry<VehicleMake> Update(VehicleMakeDTO entity)
        {
            context.ChangeTracker.Clear();
            return genericRepository.Update(mapper.Map<VehicleMake>(entity));
        }
    }
}
