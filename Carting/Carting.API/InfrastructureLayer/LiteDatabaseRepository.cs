using Carting.API.ApplicationLayer.Repository;
using Carting.API.DomainLayer.Models;
using LiteDB;

namespace Carting.API.InfrastructureLayer
{
    public class LiteDatabaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : IAggregateRoot
    {
        private readonly LiteDatabase database;
        private readonly ILiteCollection<TEntity> entityCollection;

        public LiteDatabaseRepository(ILiteDatabaseConfiguration configuration)
        {
            database = new LiteDatabase(configuration.ConnectionString);
            entityCollection = database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public void Add(TEntity entity)
        {
            entityCollection.Insert(entity);
        }

        public TEntity FindById(Guid id)
        {
            return entityCollection.Query()
                .Where(x => x.Id == id)
                .SingleOrDefault();
        }

        public void Remove(Guid id)
        {
            entityCollection.DeleteMany(x => x.Id == id);
        }
    }
}