namespace Reviews.Application.Services;

public interface ICaptchaService
{
    public Task<bool> VerifyAsync(string token);
}