namespace CloudStorage.Domain
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity?> GetByIdAsync(Guid entityId);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> RemoveAsync(TEntity entity);
        Task<TEntity> UpdateLink(TEntity entity);
        Task<TEntity?> GetIdByShareLinkAsync(string shareLink);
    }
}