using Catalog.Application.Models;

namespace Catalog.Application;

public interface ICategoryService
{
    Task<CategoryDto> AddAsync(CategoryDto cart);

    Task RemoveAsync(Guid id);

    Task<CategoryDto> GetAsync(Guid id);
}