using Catalog.Application;
using Catalog.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<CategoryDto> Get(Guid id)
        {
            return await _categoryService.GetAsync(id);
        }

        [HttpPost]
        public async Task<CategoryDto> Create(CategoryDto category)
        {
            return await _categoryService.AddAsync(category);
        }

        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await _categoryService.RemoveAsync(id);
        }
    }
}