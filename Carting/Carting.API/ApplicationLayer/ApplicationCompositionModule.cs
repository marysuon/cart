using AutoMapper;
using Carting.API.ApplicationLayer.Models;
using Carting.API.DomainLayer.Models;

namespace Carting.API.ApplicationLayer
{
    public class ApplicationCompositionModule
    {
        public static IServiceCollection RegisterDependencies(IServiceCollection builderServices)
        {
            ConfigureMapper(builderServices);

            builderServices.AddScoped<ICartService, CartService>();

            return builderServices;
        }

        private static IServiceCollection ConfigureMapper(IServiceCollection builderServices)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Cart, CartDto>().ReverseMap();
                cfg.CreateMap<Item, ItemDto>().ReverseMap();
            });
            var mapper = new Mapper(config);

            builderServices.AddSingleton<IMapper>(mapper);

            return builderServices;
        }
    }
}
