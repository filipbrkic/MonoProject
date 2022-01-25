
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MonoProject.DAL.Data;
using MonoProject.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MonoProject.Repository
{
    class GenericRepository : IGenericRepository
    {
        private readonly VehicleDbContext vehicleDbContext;

        public GenericRepository(VehicleDbContext vehicleDbContext)
        {
            this.vehicleDbContext = vehicleDbContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(Expression<Func<T, bool>> match) where T : class
        {
            var vehicle = await vehicleDbContext.Set<T>().AsNoTracking().Where(match).ToListAsync();
            return vehicle;
        }

        public async Task<(IEnumerable<T>, int)> GetAllAsync<T>(Expression<Func<T, bool>> match, Expression<Func<T, string>> orderByExpression, int take, int skip, string sortOrder) where T : class
        {
            var vehicle = sortOrder == "asc" ?
                await vehicleDbContext.Set<T>().AsNoTracking().Where(match).OrderBy(orderByExpression).Skip(skip).Take(take).ToListAsync() :
                await vehicleDbContext.Set<T>().AsNoTracking().Where(match).OrderByDescending(orderByExpression).Skip(skip).Take(take).ToListAsync();
            var vehicleCount = vehicleDbContext.Set<T>().Where(match).AsNoTracking().Count();
            return (vehicle, vehicleCount);
        }

        public EntityEntry<T> Add<T>(T entity) where T : class
        {
            return vehicleDbContext.Set<T>().Add(entity);
        }

        public async Task<EntityEntry<T>> DeleteAsync<T>(Guid id) where T : class
        {
            var entity = await GetAsync<T>(id);
            return vehicleDbContext.Set<T>().Remove(entity);
        }

        public EntityEntry<T> Delete<T>(T entity) where T : class
        {
            return vehicleDbContext.Set<T>().Remove(entity);
        }

        public async Task<T> GetAsync<T>(Guid id) where T : class
        {
            return await vehicleDbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> GetUserAsync<T>(Guid id) where T : class
        {
            return await vehicleDbContext.Set<T>().FindAsync(id);
        }

        public EntityEntry<T> Update<T>(T entity) where T : class
        {
            return vehicleDbContext.Set<T>().Update(entity);
        }
    }
}
