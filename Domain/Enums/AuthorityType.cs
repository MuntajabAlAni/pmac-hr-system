namespace Domain.Entities.Organizations.Enums
{
    /// <summary>
    /// يمثل نوع الجهة العليا داخل النظام
    /// </summary>
    public enum AuthorityType
    {
        Ministry = 1,          // وزارة
        IndependentBody = 2,   // هيئة مستقلة
        Council = 3,           // مجلس
        Secretariat = 4,       // أمانة عامة

        Presidency = 5,        // رئاسة
        Governorate = 6        // محافظة
    }
}