using Talavera.Hipermaxi.Application.Abstractions.Messaging;
using Talavera.Hipermaxi.Domain.Abstractions;
using Talavera.Hipermaxi.Domain.Users;

namespace Talavera.Hipermaxi.Application.Users.DeleteUser;

public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
        if (user is null)
        {
            return Result.Failure<Guid>(UserErrors.UserNotFound);
        }

        try
        {
            await _userRepository.DeleteAsync(user);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(user.Id);
        }
        catch (Exception e)
        {
            return Result.Failure<Guid>(UserErrors.UnexpectedError);
        }
    }
}