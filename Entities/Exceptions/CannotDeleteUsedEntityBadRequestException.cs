namespace Entities.Exceptions;

public class CannotDeleteUsedEntityBadRequestException(string entity, string usedIn) : BadRequestException(
    $"لا يمكن حذف {entity} لأنه/ـها مستخدمـ/ـة في {usedIn}");