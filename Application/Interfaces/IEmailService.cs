using Application.Email;

namespace Application.Interfaces;

public interface IEmailService
{
    Task SendEmailAsync(IEnumerable<string> to,
        string subject,
        string body,
        bool isHtml = false,
        IEnumerable<EmailAttachment>? attachments = null,
        IEnumerable<string>? cc = null);
}