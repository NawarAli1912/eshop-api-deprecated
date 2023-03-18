using eshop.Domain.Customers;
using eshop.Persistence.Repositories.Customers.DAOs;

namespace eshop.Persistence;
public static class Extensions
{
    public static CustomerDao ToDao(this Customer customer)
    {
        return new CustomerDao
        {
            Id = customer.Id.Value,
            Email = customer.Email,
            Name = customer.Name
        };
    }

    public static Customer? ToDomain(this CustomerDao customer) =>
        customer is not null ? Customer.Create(
            new Domain.Customers.ValueObjects.CustomerId(customer.Id),
            customer.Email,
            customer.Name) : null;
}
