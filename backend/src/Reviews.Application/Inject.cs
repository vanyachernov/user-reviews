using Microsoft.Extensions.DependencyInjection;
using Reviews.Application.AttachmentDirectory.Add;
using Reviews.Application.Attachments;
using Reviews.Application.CommentDirectory.Add;
using Reviews.Application.CommentDirectory.Delete;
using Reviews.Application.CommentDirectory.Get;

namespace Reviews.Application;

public static class Inject
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<AddCommentHandler>();
        
        services.AddScoped<DeleteCommentHandler>();
        
        services.AddScoped<GetCommentsHandler>();
        
        services.AddScoped<AddAttachmentHandler>();
        
        services.AddScoped<DeleteAttachmentHandler>();
        
        return services;
    }
}