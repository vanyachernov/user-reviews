using Microsoft.EntityFrameworkCore;
using Reviews.Application.AttachmentDirectory;
using Reviews.Domain.Models;

namespace Reviews.Infrastructure.Repositories;

public class AttachmentRepository(ReviewsDbContext dbContext) : IAttachmentRepository
{
    public async Task AddAsync(Attachment attachment)
    {
        await dbContext.Attachments.AddAsync(attachment);
        
        await dbContext.SaveChangesAsync();
    }

    public async Task<Attachment?> GetByIdAsync(Guid id)
    {
        return await dbContext.Attachments
            .Include(a => a.Comment)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<List<Attachment>> GetByCommentIdAsync(Guid commentId)
    {
        return await dbContext.Attachments
            .Where(a => a.CommentId == commentId)
            .ToListAsync();
    }

    public async Task DeleteAsync(Attachment attachment)
    {
        dbContext.Attachments.Remove(attachment);
        
        await dbContext.SaveChangesAsync();
    }
}