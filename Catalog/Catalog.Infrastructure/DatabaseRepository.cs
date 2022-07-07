using Catalog.Application.Repository;
using Catalog.Domain.Models;
using Microsoft.Data.SqlClient;

namespace Catalog.Infrastructure
{
    public class DatabaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : IAggregateRoot
    {
        private readonly string _connectionString;

        public DatabaseRepository(IDatabaseConfiguration configuration)
        {
            _connectionString = configuration.ConnectionString;
        }

        public async Task AddAsync(TEntity entity)
        {
            var type = typeof(TEntity);

            var values = type.GetProperties().ToDictionary(x => x.Name, x =>
            {
                var value = x.GetValue(entity);
                return value?.GetType().Name switch
                {
                    nameof(Guid) => $"'{value}'",
                    nameof(String) => $"'{value}'",
                    nameof(Double) => $"{value}",
                    nameof(Int32) => $"{value}",
                    _ => null
                } ?? "NULL";
            });

            var sqlExpression = $"INSERT INTO {type.Name} ({string.Join(", ", values.Keys)}) VALUES ({string.Join(", ", values.Values)})";
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var command = new SqlCommand();
            command.CommandText = sqlExpression;
            command.Connection = connection;
            await command.ExecuteNonQueryAsync();
        }

        public async Task<TEntity> FindByIdAsync(Guid id)
        {
            var type = typeof(TEntity);
            var sqlExpression = $"SELECT * FROM {type.Name} WHERE Id = '{id}'";

            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var command = new SqlCommand(sqlExpression, connection);
            await using var reader = await command.ExecuteReaderAsync();

            var entity = (TEntity)Activator.CreateInstance(type);

            if (reader.HasRows && await reader.ReadAsync())
            {
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    var columnName = reader.GetName(i);

                    var prop = type.GetProperty(columnName);

                    object? propertyValue = prop.PropertyType.Name switch
                    {
                        nameof(Guid) => reader.GetGuid(i),
                        nameof(String) => reader.GetString(i),
                        nameof(Decimal) => reader.GetDecimal(i),
                        nameof(Int32) => reader.GetInt32(i),
                        _ => null
                    };

                    prop.SetValue(entity, propertyValue, null);
                }
            }

            return entity;
        }

        public async Task RemoveAsync(Guid id)
        {
            var type = typeof(TEntity);
            var sqlExpression = $"DELETE FROM {type.Name} WHERE Id = '{id}'";
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var command = new SqlCommand();
            command.CommandText = sqlExpression;
            command.Connection = connection;
            await command.ExecuteNonQueryAsync();
        }
    }
}