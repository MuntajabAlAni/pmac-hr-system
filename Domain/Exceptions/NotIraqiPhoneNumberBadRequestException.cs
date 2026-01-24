namespace Domain.Exceptions;

public class NotIraqiPhoneNumberBadRequestException()
    : BadRequestException("يجب أن يكون رقم الهاتف عراقيا ويبدأ بـ (077, 078 أو 079).");