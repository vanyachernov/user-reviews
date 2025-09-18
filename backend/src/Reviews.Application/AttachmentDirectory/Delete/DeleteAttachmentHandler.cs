using Reviews.Application.AttachmentDirectory;

namespace Reviews.Application.Attachments;

public class DeleteAttachmentHandler
{
    private readonly IAttachmentRepository _attachmentRepository;

    public DeleteAttachmentHandler(IAttachmentRepository attachmentRepository)
    {
        _attachmentRepository = attachmentRepository;
    }

    public async Task<bool> Handle(Guid commentId, Guid attachmentId)
    {
        var attachment = await _attachmentRepository.GetByIdAsync(attachmentId);
        
        if (attachment == null || attachment.CommentId != commentId)
        {
            return false;
        }

        if (File.Exists(attachment.FilePath))
        {
            File.Delete(attachment.FilePath);
        }

        await _attachmentRepository.DeleteAsync(attachment);
        
        return true;
    }
}