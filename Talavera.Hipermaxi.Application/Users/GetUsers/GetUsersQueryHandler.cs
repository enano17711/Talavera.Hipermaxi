using Talavera.Hipermaxi.Application.Abstractions.Messaging;
using Talavera.Hipermaxi.Application.Users.GetUser;
using Talavera.Hipermaxi.Domain.Abstractions;
using Talavera.Hipermaxi.Domain.Users;

namespace Talavera.Hipermaxi.Application.Users.GetUsers;

public class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, ( List<UserResponse> Items, int Count)>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetUsersQueryHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<(List<UserResponse> Items, int Count)>> Handle(GetUsersQuery request,
        CancellationToken cancellationToken)
    {
        var usersCount = await _userRepository.GetCountAsync();
        var users = await _userRepository.GetAllAsync(request.Page, request.PageSize, request.SortBy, request.SortOrder,
            cancellationToken);

        var usersDto = new List<UserResponse>(users.Count);

        foreach (var user in users)
        {
            usersDto.Add(new UserResponse(user.Id, user.Name, user.BirthDate, user.Profession, user.Nationality,
                user.PhoneNumber, user.Email, user.Salary));
        }

        return Result.Success((usersDto, usersCount));
    }
}