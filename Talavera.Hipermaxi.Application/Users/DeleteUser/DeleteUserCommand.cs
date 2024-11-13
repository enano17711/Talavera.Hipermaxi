using Talavera.Hipermaxi.Application.Abstractions.Messaging;

namespace Talavera.Hipermaxi.Application.Users.DeleteUser;

public record DeleteUserCommand(Guid Id) : ICommand<Guid>;