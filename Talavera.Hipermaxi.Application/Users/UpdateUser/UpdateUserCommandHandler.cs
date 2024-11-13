using Talavera.Hipermaxi.Application.Abstractions.Messaging;
using Talavera.Hipermaxi.Domain.Abstractions;
using Talavera.Hipermaxi.Domain.Users;

namespace Talavera.Hipermaxi.Application.Users.UpdateUser;

public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
        if (user is null)
        {
            return Result.Failure<Guid>(UserErrors.UserNotFound);
        }

        user.Update(request.Name, request.BirthDate, request.Profession, request.Nationality, request.PhoneNumber,
            request.Email, request.Salary);

        try
        {
            await _userRepository.UpdateAsync(user);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success(user.Id);
        }
        catch (Exception e)
        {
            return Result.Failure<Guid>(UserErrors.UnexpectedError);
        }
    }
}