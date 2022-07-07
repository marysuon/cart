using AutoMapper;
using Carting.Application.Models;
using Carting.Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Carting.Application
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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Cart, CartDto>());
            var mapper = new Mapper(config);

            builderServices.AddSingleton<IMapper>(mapper);

            return builderServices;
        }
    }
}
