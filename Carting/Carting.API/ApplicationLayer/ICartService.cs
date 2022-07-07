using Carting.API.ApplicationLayer.Models;

namespace Carting.API.ApplicationLayer;

public interface ICartService
{
    CartDto Add(CartDto cart);

    void Remove(Guid id);

    CartDto Get(Guid id);
}