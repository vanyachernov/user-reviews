using Microsoft.EntityFrameworkCore;
using Reviews.Infrastructure;

namespace Reviews.API;

public static class Inject
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        DotNetEnv.Env.Load();

        services.AddDbContext<ReviewsDbContext>(options =>
        {
            var dbServer = Environment.GetEnvironmentVariable("DB_SERVER") ?? "localhost";
            var dbPort = Environment.GetEnvironmentVariable("DB_PORT") ?? "26957";
            var dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? "defaultdb";
            var dbUser = Environment.GetEnvironmentVariable("DB_USER") ?? "avnadmin";
            var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "here";

            var connectionString =
                $"Host={dbServer};"
                + $"Port={dbPort};"
                + $"Database={dbName};"
                + $"Username={dbUser};"
                + $"Password={dbPassword};"
                + "SSL Mode=Require;";

            options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
        });
        
        var frontEndAudience = Environment.GetEnvironmentVariable("BASE_FRONTEND_URL");
        
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.WithOrigins(frontEndAudience!);
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
            });
        });

        return services;
    }
}