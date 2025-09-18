using System.Net.Http.Json;
using Reviews.Application.CommentDirectory.Add;
using Reviews.Application.Services;

namespace Reviews.Infrastructure.Services;

public class CaptchaService : ICaptchaService
{
    private readonly HttpClient _httpClient;
    private readonly string _secretKey;

    public CaptchaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _secretKey = Environment.GetEnvironmentVariable("CAPTCHA_SECRET_KEY") ?? "secretKey";
    }

    public async Task<bool> VerifyAsync(string token)
    {
        var response = await _httpClient.PostAsync(
            $"https://www.google.com/recaptcha/api/siteverify?secret={_secretKey}&response={token}",
            null);

        var json = await response.Content.ReadFromJsonAsync<CaptchaVerifyResponse>();
        
        return json?.Success ?? false;
    }
}