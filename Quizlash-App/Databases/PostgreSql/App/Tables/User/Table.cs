namespace Quizlash_App.Databases.PostgreSql.App.Tables.User;

public class Table
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public DateTime Birthdate { get; set; }
    public string Gender { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Address1 { get; set; } = string.Empty;
    public string Address2 { get; set; } = string.Empty;
    public string PhoneCountryCode { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string CountryCode { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
}
