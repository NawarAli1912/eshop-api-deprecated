using System.Collections.Immutable;
using eshop.Domain.Common.ValueObjects;
using eshop.Domain.Customers.ValueObjects;
using eshop.Domain.Orders.ValueObjects;
using eshop.Domain.Products;

namespace eshop.Domain.Orders;

public class Order
{
    private readonly HashSet<LineItem> _lineItems = new();

    private ImmutableHashSet<LineItem> _immutableLineItems = default!;
    public IImmutableSet<LineItem> LineItems
    {
        get
        {
            // If the cache is null or outdated, create a new immutable set
            if (_immutableLineItems == null || !_immutableLineItems.SetEquals(_lineItems))
            {
                _immutableLineItems = _lineItems.ToImmutableHashSet();
            }

            // Return the cached immutable set
            return _immutableLineItems;
        }
    }

    public OrderId Id { get; private set; } = default!;

    public CustomerId CustomerId { get; private set; } = default!;

    private Order(CustomerId customerId)
    {
        Id = new OrderId(Guid.NewGuid());
        CustomerId = customerId;
    }

    public static Order Create(CustomerId customerId)
    {
        return new Order(customerId);
    }

    public void AddItem(Product product, int quantity)
    {
        var lineItem = new LineItem(
            Id,
            product.Id,
            new Money(product.Price.Currency, product.Price.Amount * quantity),
            quantity);

        _lineItems.Add(lineItem);
    }
}


