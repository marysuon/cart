namespace Catalog.Application.Models
{
    public class ItemDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public Guid Category { get; set; }

        public double Price { get; set; }

        public int Amount { get; set; }
    }
}
