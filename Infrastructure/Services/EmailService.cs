using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using Application.Interfaces;
using Application.Email;
using Infrastructure.Email;

namespace Infrastructure.Services;

public class EmailService(EmailServiceConfiguration mailServiceConfiguration) : IEmailService
{
    public async Task SendEmailAsync(IEnumerable<string> to,
        string subject,
        string body,
        bool isHtml = false,
        IEnumerable<EmailAttachment>? attachments = null,
        IEnumerable<string>? cc = null)
    {
        var smtpClient = new SmtpClient(mailServiceConfiguration.Host)
        {
            Port = mailServiceConfiguration.Port,
            Credentials = new NetworkCredential(mailServiceConfiguration.Username,
                mailServiceConfiguration.Password),
            EnableSsl = mailServiceConfiguration.EnableSsl
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(mailServiceConfiguration.FromEmail),
            Subject = subject,
            Body = body,
            IsBodyHtml = isHtml
        };

        foreach (var email in to)
        {
            mailMessage.To.Add(email);
        }

        if (cc != null)
        {
            foreach (var email in cc)
            {
                mailMessage.CC.Add(email);
            }
        }

        if (attachments != null)
        {
            foreach (var attachment in attachments)
            {
                var stream = new MemoryStream(attachment.Content);
                var mailAttachment = new Attachment(stream, attachment.Filename);

                if (!string.IsNullOrEmpty(attachment.ContentType))
                {
                    mailAttachment.ContentType = new ContentType(attachment.ContentType);
                }

                mailMessage.Attachments.Add(mailAttachment);
            }
        }

        await smtpClient.SendMailAsync(mailMessage);
    }
}