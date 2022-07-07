using Carting.API.ApplicationLayer;
using Carting.API.ApplicationLayer.Repository;
using Carting.API.InfrastructureLayer;

namespace Carting.API
{
    public class ApiCompositionModule
    {
        public static IServiceCollection RegisterDependencies(IServiceCollection builderServices,
            ConfigurationManager builderConfiguration)
        {
            var liteDatabaseConfigurationType = typeof(LiteDatabaseConfiguration);
            var liteDatabaseConfiguration = builderConfiguration.GetSection(liteDatabaseConfigurationType.Name).Get<LiteDatabaseConfiguration>();
            builderServices.AddSingleton<ILiteDatabaseConfiguration>(liteDatabaseConfiguration);

            builderServices.AddSingleton(typeof(IRepository<>), typeof(InfrastructureLayer.LiteDatabaseRepository<>));

            ApplicationCompositionModule.RegisterDependencies(builderServices);

            return builderServices;
        }
    }
}
