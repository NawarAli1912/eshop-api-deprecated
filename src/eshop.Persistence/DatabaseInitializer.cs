using System.Data.SQLite;

namespace eshop.Persistence;

public class DatabaseInitializer
{
    public static void Initialize(string connectionString)
    {
        using var connection = new SQLiteConnection(connectionString);
        var sql = @"
            CREATE TABLE IF NOT EXISTS [cust].[Customers] (
                Id UNIQUEIDENTIFIER PRIMARY KEY,
                Email NVARCHAR(256) NOT NULL,
                Name NVARCHAR(256) NOT NULL
            );
        ";
    }
}
