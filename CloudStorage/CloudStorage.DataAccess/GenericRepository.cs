using CloudStorage.Domain;
using CloudStorage.Domain.CloudFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging.Abstractions;

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

        public async Task<TEntity> UpdateLink(TEntity entity)
        {      
            var result = context.Update(entity).Entity;
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
        public Task<TEntity?> GetIdByShareLinkAsync(string  shareLink)
        {   
            var fileId = context.CloudFiles
                         .Where(b => b.SharingLink == shareLink)
                         .Select(s => s.Id)
                         .FirstOrDefault();
     
            var result = context.Set<TEntity>().FindAsync(fileId);
            return result.AsTask(); 
        }

    }
}
