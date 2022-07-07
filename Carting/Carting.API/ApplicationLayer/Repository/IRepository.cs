using Carting.API.DomainLayer.Models;

namespace Carting.API.ApplicationLayer.Repository;

public interface IRepository<TEntity>
    where TEntity : IAggregateRoot
{
    TEntity FindById(Guid id);
    void Add(TEntity entity);
    void Remove(Guid id);
}