namespace Application.Email;

public record EmailAttachment(
    byte[] Content,
    string Filename,
    string ContentType);