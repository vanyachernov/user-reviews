using Reviews.Application.DTOs;
using Reviews.Domain.Models;

namespace Reviews.Application.CommentDirectory.Extensions;

public static class CommentMapper
{
    public static CommentDto ToDto(this Comment comment)
    {
        return new CommentDto
        {
            Id = comment.Id,
            UserName = comment.User.UserName,
            Email = comment.User.Email,
            Homepage = comment.User.Homepage,
            Text = comment.Text,
            CreatedAt = comment.CreatedAt,
            Replies = comment.Replies
                .Where(r => !r.IsDeleted)
                .Select(ToDto)
                .ToList(),
            Attachments = comment.Attachments.Select(a => new AttachmentDto
            {
                Id = a.Id,
                FileName = a.FileName,
                FilePath = a.FilePath,
                MimeType = a.MimeType,
                SizeBytes = a.SizeBytes
            }).ToList()
        };
    }
}
