namespace Carting.API.DomainLayer.Models
{
    public class Cart : IAggregateRoot
    {
        public Guid Id { get; protected set; }

        public IList<Item> Items { get; protected set; }

        public static Cart Create()
        {
            return new Cart
            {
                Id = Guid.NewGuid(),
                Items = new List<Item>(),
            };
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            Items.Remove(item);
        }
    }
}