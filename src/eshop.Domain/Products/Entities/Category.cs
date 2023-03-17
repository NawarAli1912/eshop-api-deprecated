using eshop.Domain.Products.ValueObjects;

namespace eshop.Domain.Products.Entities;

public class Category
{
    private readonly List<Category> _subcategories = new();
    private readonly HashSet<Product> _products = new();

    public CategoryId Id { get; } = default!;

    public string Name { get; }

    public string Description { get; }

    public Category? ParentCategory { get; }

    public string? ImageUrl { get; }

    public bool IsFeatured { get; } = false;

    public IReadOnlyList<Category> Subcategories => _subcategories.ToList().AsReadOnly();
    public IReadOnlyList<Product> Products => _products.ToList().AsReadOnly();

    private Category(CategoryId id, string name, string description, Category? parentCategory = null, string? imageUrl = null, bool isFeatured = false)
    {
        Id = id;
        Name = name;
        Description = description;
        ParentCategory = parentCategory;
        ImageUrl = imageUrl;
        IsFeatured = isFeatured;
    }

    public static Category Create(CategoryId id, string name, string description, Category? parentCategory = null, string? imageUrl = null, bool isFeatured = false)
    {
        return new Category(id, name, description, parentCategory, imageUrl, isFeatured);
    }

    public void AddSubcategory(Category subcategory)
    {
        _subcategories.Add(subcategory);
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public void RemoveProduct(Product product)
    {
        _products.Remove(product);
    }
}
