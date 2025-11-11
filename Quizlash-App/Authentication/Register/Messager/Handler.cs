
namespace Quizlash_App.Authentication.Register.Messager;

public class Handler
{
    private readonly Quizlash_App.Databases.PostgreSql.App.QuizlashContext _context;
    public Handler(Quizlash_App.Databases.PostgreSql.App.QuizlashContext context)
    {
        _context = context;
    }
    public async Task Handle(Message message)
    {
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(message.Payload.Password, workFactor: 10);

        var newAccount = new Databases.PostgreSql.App.Tables.User.Table
        {
            Id = message.Id,
            Username = message.Payload.Username,
            FirstName = message.Payload.FirstName,
            LastName = message.Payload.LastName,
            MiddleName = message.Payload.MiddleName,
            Birthdate = DateTime.SpecifyKind(message. Payload.BirthDate, DateTimeKind.Utc),
            Gender = message.Payload.Gender,
            Email = message.Payload.Email,
            Password = hashedPassword,
            Address1 = message.Payload.Address1,
            Address2 = message.Payload.Address2,
            PhoneCountryCode = message.Payload.PhoneCountryCode,
            PhoneNumber = message.Payload.PhoneNumber,
            CountryCode = message.Payload.CountryCode,
            ZipCode = message.Payload.ZipCode
        };
        _context.Users.Add(newAccount);
        await _context.SaveChangesAsync();
    }
}
