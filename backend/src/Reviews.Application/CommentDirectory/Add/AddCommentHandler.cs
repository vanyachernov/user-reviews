using Reviews.Application.DTOs;
using Reviews.Application.Services;
using Reviews.Application.UserDirectory;
using Reviews.Domain.Models;

namespace Reviews.Application.CommentDirectory.Add;

public class AddCommentHandler
{
    private readonly ICommentRepository _commentRepository;
    private readonly IUserRepository _userRepository;
    private readonly ICaptchaService _captchaService;

    public AddCommentHandler(ICommentRepository commentRepository, IUserRepository userRepository, ICaptchaService captchaService)
    {
        _commentRepository = commentRepository;
        _userRepository = userRepository;
        _captchaService = captchaService;
    }

    public async Task<CommentDto> Handle(AddCommentRequest request)
    {
        var isValidCaptcha = await _captchaService.VerifyAsync(request.CaptchaToken);
        
        if (!isValidCaptcha)
        {
            throw new UnauthorizedAccessException("CAPTCHA verification failed! Please, try again.");
        }
        
        var user = await _userRepository.GetByEmailAsync(request.Email);
        
        if (user == null)
        {
            user = new User
            {
                UserName = request.UserName,
                Email = request.Email,
                Homepage = request.Homepage
            };
            
            await _userRepository.AddAsync(user);
        }

        var comment = new Comment
        {
            User = user,
            ParentId = request.ParentId,
            Text = request.Text
        };

        await _commentRepository.AddAsync(comment);

        return new CommentDto
        {
            Id = comment.Id,
            UserName = user.UserName,
            Email = user.Email,
            Homepage = user.Homepage,
            Text = comment.Text,
            CreatedAt = comment.CreatedAt
        };
    }
}