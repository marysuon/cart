using AutoMapper;
using Catalog.Application.Models;
using Catalog.Application.Repository;
using Catalog.Domain.Models;

namespace Catalog.Application
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IRepository<Category> categoryRepository, IMapper mapper)
        {
            this._categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> AddAsync(CategoryDto categoryDto)
        {
            var category = _mapper.Map<CategoryDto, Category>(categoryDto);
            
            await _categoryRepository.AddAsync(category);

            return _mapper.Map<Category, CategoryDto>(category);
        }

        public async Task RemoveAsync(Guid id)
        {
            await _categoryRepository.RemoveAsync(id);
        }

        public async Task<CategoryDto> GetAsync(Guid id)
        {
            var category = await _categoryRepository.FindByIdAsync(id);

            return _mapper.Map<Category, CategoryDto>(category);
        }
    }
}