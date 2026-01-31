using Domain.Models;
using System;

namespace Domain.SeededData;

public static class OfficialDocumentTypeSeed
{
    public static readonly OfficialDocumentType AdministrativeOrder = new()
    {
        Id = Guid.Parse("66666666-6666-6666-6666-666666666666"),
        Name = "أمر إداري"
    };

    public static readonly OfficialDocumentType MinisterialOrder = new()
    {
        Id = Guid.Parse("77777777-7777-7777-7777-777777777777"),
        Name = "أمر وزاري"
    };

    public static readonly OfficialDocumentType OfficialLetter = new()
    {
        Id = Guid.Parse("88888888-8888-8888-8888-888888888888"),
        Name = "كتاب رسمي"
    };

    public static readonly OfficialDocumentType InternalMemo = new()
    {
        Id = Guid.Parse("99999999-9999-9999-9999-999999999999"),
        Name = "مذكرة داخلية"
    };
}
