using Talavera.Hipermaxi.Domain.Abstraction;

namespace Talavera.Hipermaxi.Application.Abstraction.Authentication;

public interface IJwtService
{
    Task<Result<string>> GetAccessTokenAsync(
        string email,
        string password,
        CancellationToken cancellationToken = default);
}