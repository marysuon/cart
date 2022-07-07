namespace Carting.API.InfrastructureLayer;

public interface ILiteDatabaseConfiguration
{
    string ConnectionString { get; set; }
}