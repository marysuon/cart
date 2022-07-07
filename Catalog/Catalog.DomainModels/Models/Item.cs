namespace Catalog.Domain.Models
{
    public class Item : IAggregateRoot
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public string Image { get; protected set; }

        public Guid Category { get; protected set; }

        public double Price { get; protected set; }

        public int Amount { get; protected set; }
    }
}