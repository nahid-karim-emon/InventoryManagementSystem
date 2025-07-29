namespace IMS.Core.CoreInterface
{
    public interface IReadRepository
    {
        public interface IReadRepository<TEntity> where TEntity : class
        {
            Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
            Task<TEntity?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
            Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
        }
    }
}
