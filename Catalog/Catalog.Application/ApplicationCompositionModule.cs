using AutoMapper;
using Catalog.Application.Models;
using Catalog.Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Application
{
    public class ApplicationCompositionModule
    {
        public static IServiceCollection RegisterDependencies(IServiceCollection builderServices)
        {
            ConfigureMapper(builderServices);

            builderServices.AddScoped<ICategoryService, CategoryService>();
            builderServices.AddScoped<IItemService, ItemService>();

            return builderServices;
        }

        private static IServiceCollection ConfigureMapper(IServiceCollection builderServices)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, CategoryDto>().ReverseMap();
                cfg.CreateMap<Item, ItemDto>().ReverseMap();
            });

            var mapper = new Mapper(config);

            builderServices.AddSingleton<IMapper>(mapper);

            return builderServices;
        }
    }
}
