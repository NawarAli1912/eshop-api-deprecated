using eshop.Domain.Common.ValueObjects;
using eshop.Domain.Orders.ValueObjects;
using eshop.Domain.Products.ValueObjects;

public class LineItem
{
    public LineItemId Id { get; private set; } = default!;

    public OrderId OrderId { get; private set; }

    public ProductId ProductId { get; private set; }

    public Money Price { get; private set; }

    public int Quantity { get; private set; }

    internal LineItem(
        OrderId orderId,
        ProductId productId,
        Money price,
        int quantity)
    {
        Id = new LineItemId(Guid.NewGuid());
        OrderId = orderId;
        ProductId = productId;
        Price = price;
        Quantity = quantity;
    }
}
