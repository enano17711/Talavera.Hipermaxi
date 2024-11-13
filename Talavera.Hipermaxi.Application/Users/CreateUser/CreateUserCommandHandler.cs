using Talavera.Hipermaxi.Application.Abstractions.Messaging;
using Talavera.Hipermaxi.Application.Exceptions;
using Talavera.Hipermaxi.Domain.Abstractions;
using Talavera.Hipermaxi.Domain.Users;

namespace Talavera.Hipermaxi.Application.Users.CreateUser;

internal sealed class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<Result<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userFromDb = await _userRepository.FindByEmailAsync(request.Email, cancellationToken);
        if (userFromDb is not null)
        {
            return Result.Failure<Guid>(UserErrors.UserAlreadyExists);
        }

        var user = new User(Guid.NewGuid(), request.Name, request.BirthDate, request.Profession, request.Nationality,
            request.PhoneNumber, request.Email, request.Salary);

        try
        {
            _userRepository.Add(user);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
        catch (ConcurrencyException)
        {
            return Result.Failure<Guid>(UserErrors.UnexpectedError);
        }
    }
}