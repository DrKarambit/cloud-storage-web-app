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

        public List<TEntity> GetAll()
        {
            try
            {
                var result = context.Set<TEntity>().ToList();
                return result;

            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
