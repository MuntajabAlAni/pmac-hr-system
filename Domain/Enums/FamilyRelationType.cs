namespace Domain.Entities.Employees.Enums
{
    /// <summary>
    /// يمثل درجة القرابة للموظف
    /// </summary>
    public enum FamilyRelationType
    {
        Spouse = 1,          // زوج / زوجة
        Son = 2,             // ابن
        Daughter = 3,        // بنت
        Father = 4,          // أب
        Mother = 5,          // أم
        Brother = 6,         // أخ
        Sister = 7,          // أخت
        Other = 8            // أخرى
    }
}