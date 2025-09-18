using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace Reviews.Domain.Models;

public class Comment
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public User User { get; set; } = null!;
    public Comment? Parent { get; set; }
    public ICollection<Comment> Replies { get; set; } = new List<Comment>();
    [Required]
    public string Text { get; set; } = null!;
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; } = false;
    [Required]
    public Guid UserId { get; set; }
    public Guid? ParentId { get; set; }
    public List<Attachment> Attachments { get; set; } = [];
}