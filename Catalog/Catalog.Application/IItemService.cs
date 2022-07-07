using Catalog.Application.Models;

namespace Catalog.Application;

public interface IItemService
{
    Task<ItemDto> AddAsync(ItemDto cart);

    Task RemoveAsync(Guid id);

    Task<ItemDto> GetAsync(Guid id);
}