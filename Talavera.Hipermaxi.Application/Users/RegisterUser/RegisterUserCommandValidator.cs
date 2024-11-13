using FluentValidation;

namespace Talavera.Hipermaxi.Application.Users.RegisterUser;

internal sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Birthday).NotNull();
        RuleFor(x => x.Profession).NotEmpty();
        RuleFor(x => x.Nationality).NotEmpty();
        RuleFor(x => x.PhoneNumber).NotEmpty();
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Salary).NotNull();
        RuleFor(x => x.Password).NotEmpty();
    }
}