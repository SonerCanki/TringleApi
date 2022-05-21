using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TringleApi.Api.Data.Context;

namespace TringleApi.Api.Services.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _dataContext;

        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        private DbSet<T> _entities;

        public DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _dataContext.Set<T>();
                return _entities;
            }
        }

        public async Task<T> Add(T item)
        {
            try
            {
                if (item == null)
                {
                    return null;
                }
                await Entities.AddAsync(item);

                if (await Save() > 0)
                {
                    return item;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<T>> GetAll(params Expression<Func<T, object>>[] includeParameters)
        {
            IQueryable<T> queryable = Entities;
            foreach (Expression<Func<T, object>> includeParameter in includeParameters)
            {
                queryable = queryable.Include(includeParameter);
            }
            return await queryable.ToListAsync();
        }

        public async Task<T> GetByDefault(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includeParameters)
        {
            IQueryable<T> queryable = Entities;
            foreach (Expression<Func<T, object>> includeParameter in includeParameters)
            {
                queryable = queryable.Include(includeParameter);
            }
            return await queryable.FirstOrDefaultAsync(exp);
        }

        public async Task<T> Update(T item)
        {
            try
            {
                if (item == null)
                    return null;

                Entities.Update(item);

                if (await Save() > 0)
                    return item;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Save()
        {
            return await _dataContext.SaveChangesAsync();
        }

    }
}
