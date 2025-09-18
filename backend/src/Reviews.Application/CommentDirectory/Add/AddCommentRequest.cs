namespace Reviews.Application.CommentDirectory.Add;

public class AddCommentRequest
{
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Homepage { get; set; }
    public Guid? ParentId { get; set; }
    public string Text { get; set; } = null!;
}