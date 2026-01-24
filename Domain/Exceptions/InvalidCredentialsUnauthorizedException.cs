namespace Domain.Exceptions;

public class InvalidCredentialsUnauthorizedException(string email)
    : UnauthorizedException($"معلومات دخول خاطئة للمستخدم بالبريد الإلكتروني : {email}.");