using Reviews.Domain.Models;

namespace Reviews.Application.AttachmentDirectory;

public interface IAttachmentRepository
{
    Task AddAsync(Attachment attachment);
    Task<Attachment?> GetByIdAsync(Guid id);
    Task<List<Attachment>> GetByCommentIdAsync(Guid commentId);
    Task DeleteAsync(Attachment attachment);
}