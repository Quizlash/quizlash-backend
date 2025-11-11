using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Quizlash_App.Databases.PostgreSql.Identity;

public static class Extensions
{
    public static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        var identityDbConfig = configuration.GetSection("PostgreSql:Identity").Get<Config>();
        if (identityDbConfig == null)
        {
            throw new ArgumentNullException(nameof(identityDbConfig), "IdentityDb configuration section is missing or invalid.");
        }
        var identityConnectionString = new ConnectionStringBuilder()
            .SetHost(identityDbConfig.Host)
            .SetPort(identityDbConfig.Port)
            .SetDatabase(identityDbConfig.Database)
            .SetUsername(identityDbConfig.Username)
            .SetPassword(identityDbConfig.Password)
            .SetTrustServerCertificate(identityDbConfig.TrustServerCertificate)
            .Build();
        services.AddDbContext<IdentityContext>(options => options.UseNpgsql(identityConnectionString));
        services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();
        return services;
    }
}
