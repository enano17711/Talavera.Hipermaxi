using Talavera.Hipermaxi.Domain.Abstraction;

namespace Talavera.Hipermaxi.Domain.Users.Events;

public sealed record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;