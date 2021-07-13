using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MonoProject.Repository.Common
{
    public interface IGenericRepository
    {
        Task<(IEnumerable<T>, int)> GetAllAsync<T>(Expression<Func<T, bool>> match, Expression<Func<T, string>> orderByExpression, int take, int skip, string sortOrder) where T : class;
        Task<int> AddAsync<T>(T entity) where T : class;
        Task<T> GetAsync<T>(Guid id) where T : class;
        Task<T> GetUserAsync<T>(Guid id) where T : class;
        Task<int> UpdateAsync<T>(T entity) where T : class;
        Task<int> DeleteAsync<T>(Guid id) where T : class;
        Task<int> DeleteAsync<T>(T entity) where T : class;
    }
}
