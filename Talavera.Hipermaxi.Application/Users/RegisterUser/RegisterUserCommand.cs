using Talavera.Hipermaxi.Application.Abstraction.Messaging;

namespace Talavera.Hipermaxi.Application.Users.RegisterUser;

public sealed record RegisterUserCommand(
    string Name,
    DateTime Birthday,
    string Profession,
    string Nationality,
    string PhoneNumber,
    string Email,
    decimal Salary,
    string Password) : ICommand<Guid>;