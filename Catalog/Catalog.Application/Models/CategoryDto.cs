namespace Catalog.Application.Models;

public class CategoryDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Image { get; set; }

    public Guid? ParentCategory { get; set; }
}