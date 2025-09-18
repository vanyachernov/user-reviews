using Microsoft.Extensions.DependencyInjection;
using Reviews.Application.CommentDirectory;
using Reviews.Application.UserDirectory;
using Reviews.Infrastructure.Repositories;

namespace Reviews.Infrastructure;

public static class Inject
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ICommentRepository, CommentRepository>();
        
        services.AddScoped<IUserRepository, UserRepository>();
        
        return services;
    }
}