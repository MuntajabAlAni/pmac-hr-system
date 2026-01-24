namespace Domain.Exceptions;

public class ShouldUseNumbersOnlyBadRequestException()
    : BadRequestException("يجب أن تكون القيمة المدخلة مكونة من أرقام فقط.");