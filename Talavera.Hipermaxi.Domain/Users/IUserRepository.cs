namespace Talavera.Hipermaxi.Domain.Users;

public interface IUserRepository
{
    Task<int> GetCountAsync(CancellationToken cancellationToken = default);

    Task<List<User>> GetAllAsync(int page, int pageSize, string sortBy, string sortOrder,
        CancellationToken cancellationToken = default);

    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<User?> FindByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task DeleteAsync(User user, CancellationToken cancellationToken = default);
    Task UpdateAsync(User user, CancellationToken cancellationToken = default);

    void Add(User user);
}