using eshop.Domain.Products.ValueObjects;

namespace eshop.Persistence.Repositories.Products.DAOs;

public class CategoryDao
{
    public CategoryId Id { get; set; } = default!;

    public string Name { get; set; } = default!;

    public string Description { get; } = default!;

    public CategoryDao? ParentCategory { get; set; } = default!;

    public string? ImageUrl { get; set; }

    public bool IsFeatured { get; set; } = false;

    public IEnumerable<CategoryDao> Subcategories { get; set; } = Enumerable.Empty<CategoryDao>();

    public IEnumerable<ProductDao> Products { get; set; } = Enumerable.Empty<ProductDao>();
}