using Dapper;
using eshop.Domain.Customers;
using eshop.Domain.Customers.Contracts;
using eshop.Domain.Customers.ValueObjects;
using eshop.Persistence.Database;
using eshop.Persistence.Repositories.Customers.DAOs;

namespace eshop.Persistence.Repositories.Customers;

public class CustomerRepository : ICustomerRepostiory
{
    private readonly IDbConnectionFactory _connectionFactory;

    public CustomerRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<bool> CreateAsync(Customer customer)
    {
        var dao = customer.ToDao();

        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            @"INSERT INTO 
              [cust].[Customer]
                (Id, Email, Name) 
              VALUES
                (@Id, @Email, @Name)",
        dao);
        return result > 0;
    }

    public async Task<Customer?> GetAsync(CustomerId id)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        return (await connection.QueryFirstOrDefaultAsync<CustomerDao>
            ("SELECT * FROM [cust].[Customers] WHERE Id = @Id",
            new { Id = id.Value })).ToDomain();
    }
}
