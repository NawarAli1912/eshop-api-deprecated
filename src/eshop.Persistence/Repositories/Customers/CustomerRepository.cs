using Dapper;
using eshop.Domain.Customers;
using eshop.Domain.Customers.Contracts;
using eshop.Domain.Customers.ValueObjects;
using eshop.Persistence.Database;
using eshop.Persistence.Repositories.Customers.DAOs;
using eshop.Shared.Paging;
using Shared.Paging;

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

    public async Task<PagedList<Customer>> GetAll(PagingParameters paging)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var countQuery = "SELECT COUNT(*) FROM [cust].[Customers]";
        var totalCount = await connection.ExecuteScalarAsync<int>(countQuery);

        var selectQuery = @"
        SELECT Id, Email, Name
        FROM [cust].[Customers]
        ORDER BY Name
        OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";
        var parameters = new
        {
            Offset = (paging.PageNumber - 1) * paging.PageSize,
            PageSize = paging.PageSize
        };
        var customers = await connection.QueryAsync<CustomerDao>(selectQuery, parameters);

        var totalPages = (int)Math.Ceiling((double)totalCount / paging.PageSize);

        return customers.Select(c => c.ToDomain()).ToPageList(paging.PageNumber, paging.PageSize);
    }

    public async Task<Customer?> GetAsync(CustomerId id)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        return (await connection.QueryFirstOrDefaultAsync<CustomerDao>
            ("SELECT * FROM [cust].[Customers] WHERE Id = @Id",
            new { Id = id.Value })).ToDomain();
    }
}
