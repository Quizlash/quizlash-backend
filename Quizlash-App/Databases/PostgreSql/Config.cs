namespace Quizlash_App.Databases.PostgreSql;

public class Config
{
    public string Host { get; set; } = string.Empty;
    public int Port { get; set; } 
    public string Database { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string SSLMode { get; set; } = string.Empty;
    public bool TrustServerCertificate { get; set; } 
}
