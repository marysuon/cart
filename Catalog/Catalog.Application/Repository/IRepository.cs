using Catalog.Domain.Models;

namespace Catalog.Application.Repository;

public interface IRepository<TEntity>
    where TEntity : IAggregateRoot
{
    Task<TEntity> FindByIdAsync(Guid id);
    Task AddAsync(TEntity entity);
    Task RemoveAsync(Guid id);
}