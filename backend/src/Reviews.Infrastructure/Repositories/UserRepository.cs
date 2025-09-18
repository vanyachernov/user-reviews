using Microsoft.EntityFrameworkCore;
using Reviews.Application.UserDirectory;
using Reviews.Domain.Models;

namespace Reviews.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ReviewsDbContext dbContext;
    
    public UserRepository(ReviewsDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<User?> GetByEmailAsync(string email) 
        => await dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

    public async Task AddAsync(User user)
    {
        await dbContext.Users.AddAsync(user);
        await dbContext.SaveChangesAsync();
    }
}