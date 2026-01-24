namespace Domain.Exceptions;

public class StringLimitBadRequestException(string field, int length, bool isExceeded) : BadRequestException(isExceeded
    ? $"القيمة المدخلة للحقل : {field}, تجاوز الحد الأقصى للطول وهو {length} حرف !"
    : $"القيمة المدخلة للحقل : {field}, يجب أن تكون أكثر من {length} حرف على الأقل !");