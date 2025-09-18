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
            .Include(c => c.Attachments)
            .Where(c => c.ParentId == null && !c.IsDeleted)
            .OrderByDescending(c => c.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
    
    public async Task<List<Comment>> GetTopLevelWithRepliesAsync(int page, int pageSize)
    {
        return await dbContext.Comments
            .Where(c => c.ParentId == null && !c.IsDeleted)
            .Include(c => c.User)
            .Include(c => c.Attachments)
            .Include(c => c.Replies)
                .ThenInclude(r => r.User)
            .OrderByDescending(c => c.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<Comment?> GetByIdAsync(Guid id)
    {
        return await dbContext.Comments
            .Include(c => c.User)
            .Include(c => c.Attachments)
            .Include(c => c.Replies)
                .ThenInclude(r => r.User)
            .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
    }

    public async Task DeleteAsync(Comment comment)
    {
        dbContext.Comments.Remove(comment);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Comment comment)
    {
        dbContext.Comments.Update(comment);
        await dbContext.SaveChangesAsync();
    }
}