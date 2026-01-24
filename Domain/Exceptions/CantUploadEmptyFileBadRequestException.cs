namespace Domain.Exceptions;

public class CantUploadEmptyFileBadRequestException() : BadRequestException("لا يمكن رفع ملف فارغ.");