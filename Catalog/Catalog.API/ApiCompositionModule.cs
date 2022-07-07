using Catalog.Application;
using Catalog.Application.Repository;
using Catalog.Infrastructure;

namespace Catalog.API
{
    public class ApiCompositionModule
    {
        public static IServiceCollection RegisterDependencies(IServiceCollection builderServices,
            ConfigurationManager builderConfiguration)
        {
            var liteDatabaseConfigurationType = typeof(DatabaseConfiguration);
            var liteDatabaseConfiguration = builderConfiguration.GetSection(liteDatabaseConfigurationType.Name).Get<DatabaseConfiguration>();
            builderServices.AddSingleton<IDatabaseConfiguration>(liteDatabaseConfiguration);

            builderServices.AddSingleton(typeof(IRepository<>), typeof(DatabaseRepository<>));

            ApplicationCompositionModule.RegisterDependencies(builderServices);

            return builderServices;
        }
    }
}
