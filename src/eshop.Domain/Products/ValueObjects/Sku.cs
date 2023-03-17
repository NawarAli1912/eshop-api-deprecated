namespace eshop.Domain.Products.ValueObjects;

public record Sku
{
    private const int DefaultLength = 10;

    public string Value { get; init; } = string.Empty;

    private Sku(string value)
    {
        Value = value;
    }

    public static Sku? Create(string value)
    {
        if (string.IsNullOrEmpty(value) || value.Length != DefaultLength)
        {
            return null;
        }

        return new Sku(value);
    }
}
