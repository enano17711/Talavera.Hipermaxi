using Talavera.Hipermaxi.Domain.Abstractions;

namespace Talavera.Hipermaxi.Domain.Users;

public static class UserErrors
{
    public static Error UserNotFound => new("user.not.found", "User not found.");
    public static Error UserAlreadyExists => new("user.already.exists", "User already exists.");
    public static Error UnexpectedError => new("unexpected.error", "Unexpected error.");
}