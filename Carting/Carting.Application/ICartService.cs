using Carting.Application.Models;

namespace Carting.Application;

public interface ICartService
{
    CartDto Add();

    void Remove(Guid id);

    CartDto Get(Guid id);
}