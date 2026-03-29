namespace Domain.Entities.Employees.Enums
{
    /// <summary>
    /// يمثل الحالات الخاصة للموظف
    /// </summary>
    public enum SpecialEmpStatus
    {
        None = 0,                 // لا توجد حالة خاصة
        PoliticalDismissed = 1,   // مفصول سياسي
        MartyrFamily = 2,         // من ذوي الشهداء
        PoliticalPrisoner = 3,    // سجين سياسي
        Resigned = 4,             // تارك العمل
        HasMilitaryService = 5    // لديه خدمة عسكرية
    }
}