namespace HR_PMAC_BACK.Domain.Entities.EmploymentStructure.Enums
{
    /// <summary>
    /// يمثل نوع العنوان الوظيفي
    /// مرتب حسب التسلسل الإداري (الأصغر رقم = أعلى)
    /// </summary>
    public enum JobTitleType
    {
        Presidents = 1,                // رؤساء (أعلى من وزير)
        Ministers = 2,                 // وزراء
        DeputyMinisters = 3,           // وكلاء وزراء
        UniversityPresidents = 4,      // رؤساء جامعات

        DirectorGenerals = 5,          // مدراء عامين
        AssistantDirectorGenerals = 6, // معاون مدير عام
        AdministrativeLeaders = 7,     // رؤساء إداريين

        Doctors = 8,                   // أطباء
        Engineers = 9,                 // مهندسين
        AdministrativeStaff = 10,      // إداريين

        Other = 11                     // أخرى
    }
}