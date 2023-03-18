using eshop.Domain.Customers.ValueObjects;
using Shared.Paging;

namespace eshop.Domain.Customers.Contracts;

public interface ICustomerRepostiory
{
    Task<bool> CreateAsync(Customer customer);

    Task<Customer?> GetAsync(CustomerId id);

    Task<PagedList<Customer>> GetAll(PagingParameters paging);
}
