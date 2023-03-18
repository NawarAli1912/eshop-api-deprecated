using System.Data;

namespace eshop.Persistence.Database;
public interface IDbConnectionFactory
{
    public Task<IDbConnection> CreateConnectionAsync(string connectionId = "Default");
}
