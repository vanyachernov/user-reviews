using Microsoft.AspNetCore.Http;
using Reviews.Application.CommentDirectory;
using Reviews.Application.DTOs;
using Reviews.Domain.Models;

namespace Reviews.Application.AttachmentDirectory.Add;

public class AddAttachmentHandler
{
    private readonly ICommentRepository _commentRepository;
    private readonly IAttachmentRepository _attachmentRepository;
    private readonly string _uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");

    public AddAttachmentHandler(ICommentRepository commentRepository, IAttachmentRepository attachmentRepository)
    {
        _commentRepository = commentRepository;
        _attachmentRepository = attachmentRepository;
    }

    public async Task<AttachmentDto> Handle(Guid commentId, IFormFile file)
    {
        var comment = await _commentRepository.GetByIdAsync(commentId);
        
        if (comment == null)
        {
            throw new KeyNotFoundException("Comment not found");
        }

        if (!Directory.Exists(_uploadPath))
        {
            Directory.CreateDirectory(_uploadPath);
        }

        var fileName = $"{Guid.NewGuid()}_{file.FileName}";
        var filePath = Path.Combine(_uploadPath, fileName);

        await using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        var attachment = new Attachment
        {
            CommentId = comment.Id,
            FileName = file.FileName,
            FilePath = filePath,
            MimeType = file.ContentType,
            SizeBytes = (int)file.Length
        };

        await _attachmentRepository.AddAsync(attachment);

        return new AttachmentDto
        {
            Id = attachment.Id,
            FileName = attachment.FileName,
            FilePath = attachment.FilePath,
            MimeType = attachment.MimeType,
            SizeBytes = attachment.SizeBytes
        };
    }
}