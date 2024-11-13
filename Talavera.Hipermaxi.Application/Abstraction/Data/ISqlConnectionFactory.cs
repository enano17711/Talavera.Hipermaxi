using System.Data;

namespace Talavera.Hipermaxi.Application.Abstraction.Data;

public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}