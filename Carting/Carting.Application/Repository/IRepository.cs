using Carting.Domain.Models;

namespace Carting.Application.Repository;

public interface IRepository<TEntity>
    where TEntity : IAggregateRoot
{
    TEntity FindById(Guid id);
    void Add(TEntity entity);
    void Remove(Guid id);
}