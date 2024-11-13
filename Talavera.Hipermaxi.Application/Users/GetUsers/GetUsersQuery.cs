using Talavera.Hipermaxi.Application.Abstractions.Messaging;
using Talavera.Hipermaxi.Application.Users.GetUser;

namespace Talavera.Hipermaxi.Application.Users.GetUsers;

public record GetUsersQuery(
    int Page,
    int PageSize,
    string SortBy,
    string SortOrder)
    : IQuery<(List<UserResponse> Items, int Count)>;