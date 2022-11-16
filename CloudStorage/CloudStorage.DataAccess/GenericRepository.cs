using CloudStorage.Domain;
using Microsoft.EntityFrameworkCore;

namespace CloudStorage.DataAccess
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly CloudStorageDbContext context;

        public GenericRepository(CloudStorageDbContext context)
        {
            this.context = context;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var result = context.Set<TEntity>().Add(entity).Entity;
            await context.SaveChangesAsync();

            return result;
        }
        public async Task<TEntity> RemoveAsync(TEntity entity)
        {
            var result = context.Remove(entity).Entity;
            await context.SaveChangesAsync();
            
            return result;
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            var result = context.Set<TEntity>().ToListAsync();
            return result;
        }

        public Task<TEntity?> GetByIdAsync(Guid entityId)
        {
            var result = context.Set<TEntity>().FindAsync(entityId);
            return result.AsTask();
        }
    }
}
