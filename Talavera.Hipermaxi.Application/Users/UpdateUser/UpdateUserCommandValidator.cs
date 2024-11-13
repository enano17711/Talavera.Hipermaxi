using FluentValidation;

namespace Talavera.Hipermaxi.Application.Users.UpdateUser;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("Id is required.");
        RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Name is required.");
        RuleFor(x => x.BirthDate).NotNull().WithMessage("BirthDate is required.");
        RuleFor(x => x.Profession).NotEmpty().NotNull().WithMessage("Profession is required.");
        RuleFor(x => x.Nationality).NotEmpty().NotNull().WithMessage("Nationality is required.");
        RuleFor(x => x.PhoneNumber).NotEmpty().NotNull().WithMessage("PhoneNumber is required.");
        RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("Email is required.");
        RuleFor(x => x.Salary).NotNull().WithMessage("Salary is required.");
    }
}