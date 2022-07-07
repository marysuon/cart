namespace Carting.API.DomainLayer.Models;

public interface IAggregateRoot
{
    Guid Id { get; }
}