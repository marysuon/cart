namespace Catalog.Infrastructure;

public class DatabaseConfiguration : IDatabaseConfiguration
{
    public string ConnectionString { get; set; }
}