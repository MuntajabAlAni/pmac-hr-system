namespace Domain.Exceptions;

public class AlreadyExistBadRequestException(string field, string value)
    : BadRequestException($"{field} ({value}) موجود في قاعدة البيانات.");