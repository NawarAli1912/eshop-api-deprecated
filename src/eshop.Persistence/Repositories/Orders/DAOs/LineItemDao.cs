using eshop.Domain.Common.ValueObjects;
using eshop.Domain.Orders.ValueObjects;
using eshop.Domain.Products.ValueObjects;

namespace eshop.Persistence.Repositories.Orders.DAOs;
internal class LineItemDao
{
    public LineItemId Id { get; set; } = default!;

    public OrderId OrderId { get; set; } = default!;

    public ProductId ProductId { get; set; } = default!;

    public Money Price { get; set; } = default!;

    public int Quantity { get; set; }
}
