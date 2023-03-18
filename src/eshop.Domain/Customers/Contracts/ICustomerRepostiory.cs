using eshop.Domain.Customers.ValueObjects;

namespace eshop.Domain.Customers.Contracts;

public interface ICustomerRepostiory
{
    Task<bool> CreateAsync(Customer customer);

    Task<Customer?> GetAsync(CustomerId id);
}
