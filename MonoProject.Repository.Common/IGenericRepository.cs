using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MonoProject.Repository.Common
{
    public interface IGenericRepository
    {
        Task<IEnumerable<T>> GetAllAsync<T>(Expression<Func<T, bool>> match) where T : class;
        Task<(IEnumerable<T>, int)> GetAllAsync<T>(Expression<Func<T, bool>> match, Expression<Func<T, string>> orderByExpression, int take, int skip, string sortOrder) where T : class;
        EntityEntry<T> Add<T>(T entity) where T : class;
        Task<T> GetAsync<T>(Guid id) where T : class;
        Task<T> GetUserAsync<T>(Guid id) where T : class;
        EntityEntry<T> Update<T>(T entity) where T : class;
        Task<EntityEntry<T>> DeleteAsync<T>(Guid id) where T : class;
        EntityEntry<T> Delete<T>(T entity) where T : class;
    }
}
