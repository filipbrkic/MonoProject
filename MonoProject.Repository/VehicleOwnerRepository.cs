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
    public class VehicleOwnerRepository : IVehicleOwnerRepository
    {
        private readonly IMapper mapper;
        private readonly IGenericRepository genericRepository;
        private readonly VehicleDbContext context;

        public VehicleOwnerRepository(IMapper mapper, IGenericRepository genericRepository, VehicleDbContext context)
        {
            this.mapper = mapper;
            this.genericRepository = genericRepository;
            this.context = context;
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

        public EntityEntry<VehicleOwner> Add(VehicleOwnerDTO entity)
        {
            entity.Id = Guid.NewGuid();
            return genericRepository.Add(mapper.Map<VehicleOwner>(entity));
        }

        public async Task<EntityEntry<VehicleOwner>> DeleteAsync(Guid id)
        {
            return await genericRepository.DeleteAsync<VehicleOwner>(id);
        }

        public EntityEntry<VehicleOwner> Delete(VehicleOwnerDTO entity)
        {
            return genericRepository.Delete(mapper.Map<VehicleOwner>(entity));
        }

        public async Task<VehicleOwnerDTO> GetAsync(Guid id)
        {
            return mapper.Map<VehicleOwnerDTO>(await genericRepository.GetAsync<VehicleOwner>(id));
        }

        public EntityEntry<VehicleOwner> Update(VehicleOwnerDTO entity)
        {
            context.ChangeTracker.Clear();
            return genericRepository.Update(mapper.Map<VehicleOwner>(entity));
        }
    }
}
