namespace Quizlash_App.Databases.PostgreSql.App.Tables.Answer;

public class Table
{
    public Guid Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public bool IsCorrect { get; set; }
    public Guid TestId { get; set; }
}
