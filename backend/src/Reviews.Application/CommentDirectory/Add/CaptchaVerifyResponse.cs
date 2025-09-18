namespace Reviews.Application.CommentDirectory.Add;

public record CaptchaVerifyResponse (
    bool Success, 
    double Score, 
    string Action);