namespace Catalogue.Api.Models;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public List<string> Category { get; set; } = new();
    public decimal Price { get; set; }
    public DateTime PurchaseDate { get; set; }
    public string Description { get; set; } = default!;
}