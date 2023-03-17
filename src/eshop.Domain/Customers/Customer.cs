using eshop.Domain.Customers.ValueObjects;

namespace eshop.Domain.Customers;

public class Customer
{
    public CustomerId Id { get; private set; } = default!;

    public string Email { get; private set; } = string.Empty;

    public string Name { get; private set; } = string.Empty;

    private Customer(
        CustomerId id,
        string email,
        string name)
    {
        Id = id;
        Email = email;
        Name = name;
    }

    public static Customer Create(
        CustomerId id,
        string email,
        string name)
    {
        return new Customer(id, email, name);
    }
}
