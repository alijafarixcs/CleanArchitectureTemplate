namespace CleanArchitectureTemplate.Shared.Interfaces
{
    public interface IRepository<T> where T : class, IAggregateRoot
    {
        // Interface specific to repository for a single entity type
    }

    // Generic repository interface that works with various entities
    public interface IRepository
    {
        Task<T> GetByIdAsync<T, TId>(TId id, CancellationToken cancellationToken) where T : Entity<TId>, IAggregateRoot;
        Task<T> GetAsync<T, TId>(ISpecification<T> spec, CancellationToken cancellationToken) where T : Entity<TId>, IAggregateRoot;

        Task<List<T>> ListAsync<T, TId>(CancellationToken cancellationToken) where T : Entity<TId>, IAggregateRoot;
        Task<List<T>> ListAsync<T, TId>(ISpecification<T> spec, CancellationToken cancellationToken) where T : Entity<TId>, IAggregateRoot;

        Task<int> CountAsync<T, TId>(ISpecification<T> spec, CancellationToken cancellationToken) where T : Entity<TId>, IAggregateRoot;

        Task<T> AddAsync<T, TId>(T entity, CancellationToken cancellationToken) where T : Entity<TId>, IAggregateRoot;
        Task UpdateAsync<T, TId>(T entity, CancellationToken cancellationToken) where T : Entity<TId>, IAggregateRoot;
        Task DeleteAsync<T, TId>(T entity, CancellationToken cancellationToken) where T : Entity<TId>, IAggregateRoot;
    }
}
