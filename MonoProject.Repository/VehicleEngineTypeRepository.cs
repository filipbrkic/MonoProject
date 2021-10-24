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
    public class VehicleEngineTypeRepository : IVehicleEngineTypeRepository
    {
        private readonly IMapper mapper;
        private readonly IGenericRepository genericRepository;

        public VehicleEngineTypeRepository(IMapper mapper, IGenericRepository genericRepository)
        {
            this.mapper = mapper;
            this.genericRepository = genericRepository;
        }

        public async Task<IEnumerable<VehicleEngineTypeDTO>> GetAllAsync(IFiltering filtering, IPaging paging, ISorting sorting)
        {
            var result = await genericRepository.GetAllAsync<VehicleEngineType>(CreateFilterExpression(filtering.Search, filtering.SearchBy), CreateOrderByExpression(sorting.SortBy), paging.PageSize, paging.Skip, sorting.SortOrder);
            paging.TotalItemsCount = result.Item2;
            return mapper.Map<IEnumerable<VehicleEngineTypeDTO>>(result.Item1);
        }
        private static Expression<Func<VehicleEngineType, bool>> CreateFilterExpression(string search, string searchBy)
        {
            if (!string.IsNullOrEmpty(search))
            {
                return v => searchBy == "Type" ?
                v.Type.IndexOf(search) > -1 :
                v.Abrv.IndexOf(search) > -1;
            }
            return x => x.Type.StartsWith(String.Empty);
        }
        private static Expression<Func<VehicleEngineType, string>> CreateOrderByExpression(string sortBy)
        {
            if (sortBy == "Type" || sortBy == null)
            {
                return v => v.Type;
            }
            else
            {
                return v => v.Abrv;
            }
        }

        public async Task<VehicleEngineTypeDTO> GetAsync(Guid id)
        {
            return mapper.Map<VehicleEngineTypeDTO>(await genericRepository.GetAsync<VehicleEngineType>(id));
        }
    }
}
