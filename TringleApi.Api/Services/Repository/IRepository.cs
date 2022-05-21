using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TringleApi.Api.Services.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> Add(T item);
        Task<T> Update(T item);
        Task<int> Save();
        Task<List<T>> GetAll(params Expression<Func<T, object>>[] includeParameters);
        Task<T> GetByDefault(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includeParameters);
    }
}
