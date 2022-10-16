namespace CloudStorage.Domain
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity entity);
        List<TEntity> GetAll();
    }
}