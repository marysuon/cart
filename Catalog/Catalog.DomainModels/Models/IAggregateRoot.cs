namespace Catalog.Domain.Models;

public interface IAggregateRoot
{
    Guid Id { get; }
}