using Quizlash_App.Databases.PostgreSql.App;
using Quizlash_App.Databases.PostgreSql.Identity;

namespace Quizlash_App.Databases;

public static class Extensions
{
    public static IServiceCollection AddDatabases(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPostgre(configuration);
        services.AddIdentity(configuration);
        return services;
    }
}
