using eshop.Domain.Common.ValueObjects;
using eshop.Domain.Products.ValueObjects;

namespace eshop.Persistence.Repositories.Products.DAOs;
public class ProductDao
{
    public ProductId Id { get; set; } = default!;

    public CategoryId CategoryId { get; set; } = default!;

    public string Name { get; set; } = string.Empty;

    public Money Price { get; set; } = default!;

    public Sku Sku { get; set; } = default!;
}
