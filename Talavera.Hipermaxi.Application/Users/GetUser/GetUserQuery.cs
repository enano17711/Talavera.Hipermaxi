using Talavera.Hipermaxi.Application.Abstractions.Messaging;

namespace Talavera.Hipermaxi.Application.Users.GetUser;

public sealed record GetUserQuery(Guid Id) : IQuery<UserResponse>;