using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace eshop.Persistence.Database;
public class SqlConnectionFactory : IDbConnectionFactory
{
    private readonly IConfiguration _config;

    public SqlConnectionFactory(IConfiguration config)
    {
        _config = config;
    }
    public async Task<IDbConnection> CreateConnectionAsync(string connectionId = "Default")
    {
        var connectionString = _config.GetConnectionString(connectionId);
        var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();
        return connection;
    }
}
