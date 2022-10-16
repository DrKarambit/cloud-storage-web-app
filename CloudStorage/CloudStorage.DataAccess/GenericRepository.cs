using CloudStorage.Domain;

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

        public List<TEntity> GetAll()
        {
            var result = context.Set<TEntity>().ToList();
            return result;
        }
    }
}
