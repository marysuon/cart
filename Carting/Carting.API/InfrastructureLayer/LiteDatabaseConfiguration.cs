namespace Carting.API.InfrastructureLayer;

public class LiteDatabaseConfiguration : ILiteDatabaseConfiguration
{
    public string ConnectionString { get; set; }
}