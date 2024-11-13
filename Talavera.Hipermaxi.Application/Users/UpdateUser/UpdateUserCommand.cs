using Talavera.Hipermaxi.Application.Abstractions.Messaging;

namespace Talavera.Hipermaxi.Application.Users.UpdateUser;

public record UpdateUserCommand(
    Guid Id,
    string Name,
    DateTime BirthDate,
    string Profession,
    string Nationality,
    string PhoneNumber,
    string Email,
    decimal Salary) : ICommand<Guid>;