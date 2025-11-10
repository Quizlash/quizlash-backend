using Microsoft.EntityFrameworkCore;

namespace Quizlash_App.Databases.PostgreSql.Identity;

public static class Extensions
{
    public static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IdentityContext>(options => options.UseNpgsql("Host=db.jkwknlkewajuamsddivk.supabase.co;Port=5432;Database=identity;Username=postgres;Password=Duykhoa2kk;SSL Mode=Require;Trust Server Certificate=true"));
        return services;
    }
}
