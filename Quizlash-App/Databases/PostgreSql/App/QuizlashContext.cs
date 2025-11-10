using Microsoft.EntityFrameworkCore;
using Quizlash_App.Databases.PostgreSql.App.Tables.User;

namespace Quizlash_App.Databases.PostgreSql.App;

public class QuizlashContext:DbContext
{
    public QuizlashContext(DbContextOptions<QuizlashContext> options) : base(options) 
    {}
    public DbSet<Table> Users { get; set; }
}
