namespace Quizlash_App.Databases.PostgreSql.App.Tables.Test;

public class Table
{
    public Guid Id { get; set; }
    public int Duration { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public int NumberOfQuestions { get; set; }  

}
