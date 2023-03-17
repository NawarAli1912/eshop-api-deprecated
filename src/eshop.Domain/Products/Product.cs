using eshop.Domain.Common.ValueObjects;
using eshop.Domain.Products.ValueObjects;

namespace eshop.Domain.Products;

public class Product
{
    public ProductId Id { get; private set; } = default!;

    public CategoryId CategoryId { get; private set; } = default!;

    public string Name { get; private set; } = string.Empty;

    public Money Price { get; private set; } = default!;

    public Sku Sku { get; private set; } = default!;

    private Product(
        ProductId id,
        CategoryId categoryId,
        string name,
        Money price,
        Sku sku)
    {
        Id = id;
        Name = name;
        Price = price;
        Sku = sku;
    }

    public static Product Create(
        ProductId id,
        CategoryId categoryId,
        string name,
        Money price,
        Sku sku)
    {
        return new Product(id, categoryId, name, price, sku);
    }
}
