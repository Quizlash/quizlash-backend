using Wolverine;

namespace Quizlash_App.Wolverine;

public static class Extensions
{
    public static IServiceCollection AddWolverines(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddWolverine(opt =>
        {
            opt.PublishMessage<Authentication.Register.Messager.Message>().ToLocalQueue("account-register");
        });
        return services;
    }
}
