using Microsoft.EntityFrameworkCore;

namespace Quizlash_App.Databases.PostgreSql.App;

public static class Extensions
{
    public static IServiceCollection AddPostgre(this IServiceCollection services, IConfiguration configuration)
    {
        var appDbConfig = configuration.GetSection("PostgreSql:App").Get<Config>();
        if (appDbConfig == null)
        {
            throw new ArgumentNullException(nameof(appDbConfig), "App configuration section is missing or invalid.");
        }
        var appConnectionString = new ConnectionStringBuilder()
            .SetHost(appDbConfig.Host)
            .SetPort(appDbConfig.Port)
            .SetDatabase(appDbConfig.Database)
            .SetUsername(appDbConfig.Username)
            .SetPassword(appDbConfig.Password)
            .SetTrustServerCertificate(appDbConfig.TrustServerCertificate)
            .Build();
        services.AddDbContext<QuizlashContext>(options => options.UseNpgsql(appConnectionString));
        return services;
    }
}
