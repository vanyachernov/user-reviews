using Reviews.Domain.Models;

namespace Reviews.Application.CommentDirectory;

public interface ICommentRepository
{
    public Task AddAsync(Comment comment);
    public Task<List<Comment>> GetTopLevelAsync(int page, int pageSize);
    public Task<List<Comment>> GetTopLevelWithRepliesAsync(int page, int pageSize);
    public Task<Comment?> GetByIdAsync(Guid id);
    public Task DeleteAsync(Comment comment);
    public Task UpdateAsync(Comment comment);
}