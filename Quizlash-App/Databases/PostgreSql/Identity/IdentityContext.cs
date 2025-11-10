using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Quizlash_App.Databases.PostgreSql.Identity;

public class IdentityContext:IdentityDbContext
{
    public IdentityContext(DbContextOptions<IdentityContext>options):base(options) 
    {}
}
