using FluentValidation;

namespace Talavera.Hipermaxi.Application.Users.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.BirthDate).NotNull();
        RuleFor(x => x.Profession).NotEmpty();
        RuleFor(x => x.Nationality).NotEmpty();
        RuleFor(x => x.PhoneNumber).NotEmpty();
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Salary).NotNull();
    }
}