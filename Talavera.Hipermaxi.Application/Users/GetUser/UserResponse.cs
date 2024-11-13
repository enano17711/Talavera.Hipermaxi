namespace Talavera.Hipermaxi.Application.Users.GetUser;

public record UserResponse(
    Guid Id,
    string Name,
    DateTime BirthDate,
    string Profession,
    string Nationality,
    string PhoneNumber,
    string Email,
    decimal Salary);