using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quizlash_App.Databases.PostgreSql.App;

namespace Quizlash_App.Users;

[Route("api/users")]
[ApiController]
public class Controller : ControllerBase
{
    private readonly QuizlashContext _context;
    public Controller(QuizlashContext context)
    {
        _context = context;
    }
    [HttpPost]
    public IActionResult Post([FromBody] POST.Payload payload)
    {
        // Implementation for creating a new user
        return Ok();
    }
}
