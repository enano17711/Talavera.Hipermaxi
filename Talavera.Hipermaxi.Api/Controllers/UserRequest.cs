namespace Talavera.Hipermaxi.Api.Controllers;

public record UserRequest(
    string Name,
    DateTime BirthDate,
    string Profession,
    string Nationality,
    string PhoneNumber,
    string Email,
    decimal Salary);