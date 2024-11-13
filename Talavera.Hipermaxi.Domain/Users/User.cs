using Talavera.Hipermaxi.Domain.Abstractions;

namespace Talavera.Hipermaxi.Domain.Users;

public class User : Entity
{
    /*nombre, fecha nacimiento, profesión, nacionalidad, teléfono,
        correo, sueldo.*/

    public User(Guid id, string name, DateTime birthDate, string profession, string nationality, string phoneNumber,
        string email, decimal salary) : base(id)
    {
        Name = name;
        BirthDate = birthDate;
        Profession = profession;
        Nationality = nationality;
        PhoneNumber = phoneNumber;
        Email = email;
        Salary = salary;
    }

    public User()
    {
    }

    public string Name { get; private set; }
    public DateTime BirthDate { get; private set; }
    public string Profession { get; private set; }
    public string Nationality { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public decimal Salary { get; private set; }

    public void Update(string requestName, DateTime requestBirthDate, string requestProfession,
        string requestNationality, string requestPhoneNumber, string requestEmail, decimal requestSalary)
    {
        Name = requestName;
        BirthDate = requestBirthDate;
        Profession = requestProfession;
        Nationality = requestNationality;
        PhoneNumber = requestPhoneNumber;
        Email = requestEmail;
        Salary = requestSalary;
    }
}