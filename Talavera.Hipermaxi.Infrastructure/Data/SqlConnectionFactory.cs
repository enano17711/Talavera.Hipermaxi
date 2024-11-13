using System.Data;
using Microsoft.Data.SqlClient;
using Talavera.Hipermaxi.Application.Abstraction.Data;

namespace Talavera.Hipermaxi.Infrastructure.Data;

internal sealed class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly string _connectionString;

    public SqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    // SqlServer connection
    public IDbConnection CreateConnection()
    {
        var connection = new SqlConnection(_connectionString);
        connection.Open();

        return connection;
    }
}