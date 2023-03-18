using eshop.Domain.Customers.ValueObjects;
using eshop.Domain.Orders.ValueObjects;

namespace eshop.Persistence.Repositories.Orders.DAOs;
internal class OrderDao
{
    public OrderId Id { get; private set; } = default!;

    public CustomerId CustomerId { get; private set; } = default!;

    public IEnumerable<LineItemDao> LineItems { get; set; } = Enumerable.Empty<LineItemDao>();
}
