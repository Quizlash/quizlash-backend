namespace Quizlash_App.Databases.PostgreSql.App.Tables.TestQuestion;

public class Table
{
    public Guid Id { get; set; }
    public Guid TestId { get; set; }
    public Guid QuestionId { get; set; }
    public int TestAnswer { get; set; }
    public bool IsCorrect { get; set; }
}
