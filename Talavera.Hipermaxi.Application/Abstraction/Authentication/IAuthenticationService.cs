using Talavera.Hipermaxi.Domain.Users;

namespace Talavera.Hipermaxi.Application.Abstraction.Authentication;

public interface IAuthenticationService
{
    Task<string> RegisterAsync(
        User user,
        string password,
        CancellationToken cancellationToken = default);
}