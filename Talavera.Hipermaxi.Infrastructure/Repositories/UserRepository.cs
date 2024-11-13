using Talavera.Hipermaxi.Domain.Users;

namespace Talavera.Hipermaxi.Infrastructure.Repositories;

internal sealed class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }
}