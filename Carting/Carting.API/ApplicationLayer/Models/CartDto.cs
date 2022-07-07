namespace Carting.API.ApplicationLayer.Models
{
    public class CartDto
    {
        public Guid Id { get; set; }

        public IList<ItemDto> Items { get; set; }
    }
}
