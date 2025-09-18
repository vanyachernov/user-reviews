using Microsoft.Extensions.DependencyInjection;
using Reviews.Application.CommentDirectory.Add;

namespace Reviews.Application;

public static class Inject
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<AddCommentHandler>();
        
        return services;
    }
}