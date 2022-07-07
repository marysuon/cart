namespace Carting.Domain.Models;

public interface IAggregateRoot
{
    Guid Id { get; }
}