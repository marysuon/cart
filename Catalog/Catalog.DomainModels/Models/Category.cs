namespace Catalog.Domain.Models
{
    public class Category : IAggregateRoot
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Image { get; protected set; }

        public Guid? ParentCategory  { get; protected set; }
    }
}