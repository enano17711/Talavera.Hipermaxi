using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Talavera.Hipermaxi.Domain.Users;

namespace Talavera.Hipermaxi.Infrastructure.Repositories;

internal sealed class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<int> GetCountAsync(CancellationToken cancellationToken = default)
    {
        return await DbContext
            .Set<User>()
            .CountAsync(cancellationToken);
    }

    public async Task<List<User>> GetAllAsync(int page, int pageSize, string sortBy, string sortOrder, string filterBy,
        string filterValue,
        CancellationToken cancellationToken = default)
    {
        var orderByMap = new Dictionary<string, Expression<Func<User, object>>>
        {
            { "Name", x => x.Name },
            { "Email", x => x.Email },
            { "Id", x => x.Id },
            { "Salary", x => x.Salary },
            { "PhoneNumber", x => x.PhoneNumber },
            { "Profession", x => x.Profession },
            { "Nationality", x => x.Nationality },
            // add more mappings as needed
        };

        var queryResultAsc = DbContext
            .Set<User>()
            /*.Where(x => x.Name.Contains(filterValue))*/
            .OrderBy(orderByMap[sortBy])
            .Skip((page - 1) * pageSize)
            .Take(pageSize);

        var queryResultDesc = DbContext
            .Set<User>()
            /*.Where(x => x.Name.Contains(filterValue))*/
            .OrderByDescending(orderByMap[sortBy])
            .Skip((page - 1) * pageSize)
            .Take(pageSize);


        return sortOrder == "asc"
            ? await queryResultAsc.ToListAsync(cancellationToken: cancellationToken)
            : await queryResultDesc.ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<User?> FindByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await DbContext
            .Set<User>()
            .FirstOrDefaultAsync(user => user.Email == email, cancellationToken);
    }

    public async Task DeleteAsync(User user, CancellationToken cancellationToken = default)
    {
        DbContext.Remove(user);
    }

    public async Task UpdateAsync(User user, CancellationToken cancellationToken = default)
    {
        DbContext.Update(user);
    }
}