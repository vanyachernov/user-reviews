using Reviews.Domain.Models;

namespace Reviews.Application.UserDirectory;

public interface IUserRepository
{
    public Task<User?> GetByEmailAsync(string email);
    public Task AddAsync(User user);
}