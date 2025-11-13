namespace Quizlash_App.Authentication.Register.Messager;

public record Message(
    Guid Id,
    RegisterPayload Payload
    );
