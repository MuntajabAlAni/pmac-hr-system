namespace Domain.Entities.EmploymentStructure.Enums
{
    /// <summary>
    /// يمثل المستوى الإداري للمنصب
    /// كلما كان الرقم أصغر كان المنصب أعلى
    /// </summary>
    public enum PositionLevel
    {
        President = 1,                 // رئيس جمهورية
        PrimeMinister = 2,             // رئيس وزراء

        Minister = 3,                  // وزير
        DeputyMinister = 4,            // وكيل وزارة

        ChiefOfDiwanOffice = 5,        // مدير مكتب رئيس ديوان
        Advisor = 6,                   // مستشار

        DirectorGeneral = 7,           // مدير عام
        AssistantDirectorGeneral = 8,  // معاون مدير عام

        DepartmentHead = 9,            // رئيس قسم
        SectionHead = 10,              // رئيس شعبة
        UnitHead = 11                  // مسؤول وحدة
    }
}