namespace Domain.Exceptions;

public class ExpiredRefreshTokenUnauthorizedException()
    : BadRequestException("انتهت صلاحية رمز التحديث، يرجى تسجيل الدخول مرة أخرى.");