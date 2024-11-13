using System.Data;

namespace Talavera.Hipermaxi.Application.Abstractions.Data;

public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}