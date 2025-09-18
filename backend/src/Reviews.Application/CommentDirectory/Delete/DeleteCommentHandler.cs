namespace Reviews.Application.CommentDirectory.Delete;

public class DeleteCommentHandler
{
    private readonly ICommentRepository _commentRepository;

    public DeleteCommentHandler(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<bool> Handle(Guid id)
    {
        var comment = await _commentRepository.GetByIdAsync(id);
        
        if (comment == null)
        {
            return false;
        }

        comment.IsDeleted = true;
        
        await _commentRepository.UpdateAsync(comment);

        return true;
    }
}