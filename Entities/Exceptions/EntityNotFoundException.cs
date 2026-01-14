namespace Entities.Exceptions;

public class EntityNotFoundException(string entity, string field, dynamic value)
    : NotFoundException($"الـ {entity} ذو {field}: {value} غير موجود في قاعدة البيانات.");