using Reviews.Domain.Models;

namespace Reviews.Application.CommentDirectory;

public interface ICommentRepository
{
    public Task AddAsync(Comment comment);
    public Task<List<Comment>> GetTopLevelAsync(int page, int pageSize);
}