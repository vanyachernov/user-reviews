using Microsoft.Extensions.DependencyInjection;
using Reviews.Application.AttachmentDirectory;
using Reviews.Application.CommentDirectory;
using Reviews.Application.Services;
using Reviews.Application.UserDirectory;
using Reviews.Infrastructure.Repositories;
using Reviews.Infrastructure.Services;

namespace Reviews.Infrastructure;

public static class Inject
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ICommentRepository, CommentRepository>();
        
        services.AddScoped<IUserRepository, UserRepository>();
        
        services.AddHttpClient<ICaptchaService, CaptchaService>();
        
        services.AddHttpClient<IAttachmentRepository, AttachmentRepository>();
        
        return services;
    }
}