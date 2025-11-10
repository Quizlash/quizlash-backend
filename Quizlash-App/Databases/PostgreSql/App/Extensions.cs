using Microsoft.EntityFrameworkCore;

namespace Quizlash_App.Databases.PostgreSql.App;

public static class Extensions
{
    public static IServiceCollection AddPostgre(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<QuizlashContext>(options => options.UseNpgsql("Host=db.bibidonjvkgdmqggcawj.supabase.co;Port=5432;Database=quizlash;Username=postgres;Password=Duykhoa2kk;SSL Mode=Require;Trust Server Certificate=true"));
        return services;
    }
}
