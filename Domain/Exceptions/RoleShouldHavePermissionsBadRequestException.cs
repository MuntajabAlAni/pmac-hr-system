namespace Domain.Exceptions;

public class RoleShouldHavePermissionsBadRequestException()
    : BadRequestException("يجب أن يكون للدور صلاحية واحدة على الأقل.");