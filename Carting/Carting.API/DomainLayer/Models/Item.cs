namespace Carting.API.DomainLayer.Models
{
    public class Item
    {
        public int Id { get; protected set; }

        public string Name { get; protected set; }

        public string Image { get; protected set; }

        public double Price { get; protected set; }

        public int Quantity { get; protected set; }
    }
}