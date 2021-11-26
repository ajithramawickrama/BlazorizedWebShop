namespace MyFirstBlazorApp.Models;

public class Product
{
    public int Id { get; set; }
    public int Code { get; set; }
    public string? Description { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal DiscountPrice { get; set; }
    public string? Unit { get; set; }
}

