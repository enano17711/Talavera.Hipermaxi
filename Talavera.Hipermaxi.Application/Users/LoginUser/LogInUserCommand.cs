using Talavera.Hipermaxi.Application.Abstraction.Messaging;

namespace Talavera.Hipermaxi.Application.Users.LoginUser;

public sealed record LogInUserCommand(string Email, string Password)
    : ICommand<AccessTokenResponse>;