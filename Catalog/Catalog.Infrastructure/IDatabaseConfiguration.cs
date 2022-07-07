namespace Catalog.Infrastructure;

public interface IDatabaseConfiguration
{
    string ConnectionString { get; set; }
}