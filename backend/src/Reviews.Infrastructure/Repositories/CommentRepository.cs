using Microsoft.EntityFrameworkCore;
using Reviews.Application.CommentDirectory;
using Reviews.Domain.Models;

namespace Reviews.Infrastructure.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly ReviewsDbContext dbContext;
    
    public CommentRepository(ReviewsDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    public async Task AddAsync(Comment comment)
    {
        await dbContext.Comments.AddAsync(comment);
        await dbContext.SaveChangesAsync();
    }

    public async Task<List<Comment>> GetTopLevelAsync(int page, int pageSize)
    {
        return await dbContext.Comments
            .Include(c => c.User)
            .Where(c => c.ParentId == null)
            .OrderByDescending(c => c.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
}