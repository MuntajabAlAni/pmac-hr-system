namespace Shared.Email;

public record EmailServiceConfiguration(
    string Host,
    int Port,
    string Username,
    string Password,
    string FromEmail,
    bool EnableSsl
);