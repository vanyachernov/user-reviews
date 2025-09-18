using Reviews.Application.CommentDirectory.Extensions;
using Reviews.Application.DTOs;

namespace Reviews.Application.CommentDirectory.Get;

public class GetCommentsHandler
{
    private readonly ICommentRepository _commentRepository;

    public GetCommentsHandler(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<List<CommentDto>> Handle(int page, int pageSize)
    {
        var comments = await _commentRepository.GetTopLevelWithRepliesAsync(page, pageSize);

        return comments.Select(c => c.ToDto()).ToList();
    }
}