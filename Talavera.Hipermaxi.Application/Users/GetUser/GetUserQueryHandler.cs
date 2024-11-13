using Talavera.Hipermaxi.Application.Abstractions.Messaging;
using Talavera.Hipermaxi.Domain.Abstractions;
using Talavera.Hipermaxi.Domain.Users;

namespace Talavera.Hipermaxi.Application.Users.GetUser;

public class GetUserQueryHandler : IQueryHandler<GetUserQuery, UserResponse>
{
    private readonly IUserRepository _userRepository;

    public GetUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<UserResponse>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

        if (user is null)
        {
            return Result.Failure<UserResponse>(UserErrors.UserNotFound);
        }

        return new UserResponse(user.Id, user.Name, user.BirthDate, user.Profession, user.Nationality, user.PhoneNumber,
            user.Email, user.Salary);
    }
}