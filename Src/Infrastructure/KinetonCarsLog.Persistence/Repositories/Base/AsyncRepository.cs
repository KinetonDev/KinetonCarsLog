using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KinetonCarsLog.Application.Contracts;
using KinetonCarsLog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KinetonCarsLog.Persistence.Repositories.Base
{
    public abstract class AsyncRepository<T> : IAsyncRepository<T> where T: Entity
    {
        protected readonly DbContext DbContext;

        protected AsyncRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }
        
        public async Task<T> GetAsync(int id)
        {
            return await GetAsync(id, CancellationToken.None);
        }

        public async Task<T> GetAsync(int id, CancellationToken cancellationToken)
        {
            return await DbContext.Set<T>().FirstOrDefaultAsync(e => e.Id == id, cancellationToken: cancellationToken);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await GetAllAsync(CancellationToken.None);
        }
        
        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await DbContext.Set<T>().ToListAsync(cancellationToken: cancellationToken);
        }

        public async Task AddAsync(T entity)
        {
            await AddAsync(entity, CancellationToken.None);
        }
        
        public async Task AddAsync(T entity, CancellationToken cancellationToken)
        {
            await DbContext.Set<T>().AddAsync(entity, cancellationToken);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await AddRangeAsync(entities, CancellationToken.None);
        }
        
        public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
        {
            await DbContext.Set<T>().AddRangeAsync(entities, cancellationToken);
        }

        public async Task RemoveAsync(T entity)
        {
            DbContext.Set<T>().Remove(entity);
            await Task.CompletedTask;
        }
        
        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            DbContext.Set<T>().RemoveRange(entities);
            await Task.CompletedTask;
        }
    }
}