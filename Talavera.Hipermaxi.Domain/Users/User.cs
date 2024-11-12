using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talavera.Hipermaxi.Domain.Abstraction;
using Talavera.Hipermaxi.Domain.Users.Events;

namespace Talavera.Hipermaxi.Domain.Users
{
    public sealed class User : Entity
    {
        public User(Guid id, string name, DateTime birthday, string profession, string nationality, string phoneNumber,
            string email, decimal salary) : base(id)
        {
            Name = name;
            Birthday = birthday;
            Profession = profession;
            Nationality = nationality;
            PhoneNumber = phoneNumber;
            Email = email;
            Salary = salary;
        }

        public User()
        {
        }

        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Profession { get; set; }
        public string Nationality { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public string IdentityId { get; private set; }

        public static User Create(string name, DateTime birthday, string profession, string nationality,
            string phoneNumber, string email, decimal salary)
        {
            var user = new User(Guid.NewGuid(), name, birthday, profession, nationality, phoneNumber, email, salary);

            user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));

            return user;
        }

        public void SetIdentityId(string identityId)
        {
            IdentityId = identityId;
        }
    }
}