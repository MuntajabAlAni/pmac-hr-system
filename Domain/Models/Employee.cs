using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Models
{
    public class Employee
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Store_Emp_Id")]
        public Guid StoreEmployeeId { get; set; }

        [DisplayName("الاسم الكامل")]
        public string? FullName { get; set; } // Kept as cached full name usually needed

        //------------------------------------------------Personal info
        [DisplayName("الاسم الاول")]
        [Required]
        public required string FirstName { get; set; }

        [DisplayName("الاسم الثاني")]
        public string? SecondName { get; set; }

        [DisplayName("الاسم الثالث")]
        public string? ThirdName { get; set; }

        [DisplayName("الاسم الرابع")]
        public string? FourthName { get; set; }

        [DisplayName("اللقب")]
        public string? LastName { get; set; }

        [DisplayName("اسم الام الثلاثي")]
        public string? MotherName { get; set; }

        [DisplayName("اسم الموظف الثلاثي  باللغة الانكليزية")]
        public string? MotherNameEnglish { get; set; }

        [DisplayName("الجنس")]
        public Guid? GenderId { get; set; }

        //--------------------------Relationships----------------------------------------
        [ForeignKey("GenderId")]
        public virtual Gender? Gender { get; set; }

        [DisplayName("فصيلة الدم")]
        public string? BloodGroup { get; set; }

        [DisplayName("القومية")]
        public string? Nationality { get; set; }

        [DisplayName("الديانة")]
        public string? Religion { get; set; }

        [DisplayName("محل الولادة")]
        public string? PlaceOfBirth { get; set; }

        [DisplayName("تأريخ الولادة")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }

        //----------------------------------------------------------
        [DisplayName("الحالة الزوجية")]
        public Guid? MaritalStatusId { get; set; }

        [ForeignKey("MaritalStatusId")]
        public virtual MaritalStatus? MaritalStatus { get; set; }

        //-----------------------------------------------------------

        [DisplayName("عدد الاطفال")]
        public string? NumberOfChildren { get; set; }

        [DisplayName("اسم الزوج/ الزوجة")]
        public string? SpouseName { get; set; }

        [DisplayName("عمل الزوج/ الزوجة")]
        public string? SpouseJob { get; set; }

        [DisplayName("رقم الهاتف")]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }

        [DisplayName("العنوان الكامل")]
        public string? FullAddress { get; set; } // Merged address fields

        //-------------------------معلومات هوية الاحوال او البطاقة الوطنية

        [DisplayName("رقم هوية الاحوال المدنية")]
        public string? CivilIdNumber { get; set; }

        [DisplayName("رقم السجل")]
        public string? RecordNumber { get; set; }

        [DisplayName("رقم الصحيفة")]
        public string? PageNumber { get; set; }

        [DisplayName("جهة الاصدار")]
        public string? Publisher { get; set; }

        [DisplayName("تأريخ الاصدار")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfIssuance { get; set; }

        [DisplayName("رقم البطاقة الوطنية")]
        public string? NationalCardNumber { get; set; }

        [DisplayName("تأريخ الاصدار")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? NationalCardIssuanceDate { get; set; }

        //------------------------معلومات شهادة الجنسية

        [DisplayName("رقم الشهادة")]
        public string? CertificateNumber { get; set; }

        [DisplayName("رقم المحفظة")]
        public string? PocketNumber { get; set; }

        [DisplayName("جهة الاصدار")]
        public string? CertificatePublisher { get; set; }

        [DisplayName("تأريخ الاصدار")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CertificateIssuanceDate { get; set; }

        //------------------------------------Housing info-----------------

        [DisplayName("اسم مكتب المعلومات")]
        public string? InformationOfficeName { get; set; }

        [DisplayName("رقم البطاقة")]
        public string? HousingCardNumber { get; set; }

        [DisplayName("تأريخ التنظيم")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? HousingCardIssuanceDate { get; set; }

        //-----------------------------supplying card info

        [DisplayName("رقم البطاقة")]
        public string? SupplyingCardNumber { get; set; }

        [DisplayName("اسم مركز التموين")]
        public string? SupplyCenterName { get; set; }

        [DisplayName("رقم مركز التموين")]
        public string? SupplyCenterNumber { get; set; }

        [DisplayName("الملاحظات")]
        public string? SupplyNotes { get; set; }

        //--------------------------------------file path-------------------------

        [DisplayName("رابط ملف المرفقات")]
        public string? FilePath { get; set; }

        //--------------------------------------Prof_Pic-------------------------

        [DisplayName("الصورة الشخصية")]
        public string? ProfilePicture { get; set; }

        [DisplayName("البريد الالكتروني")]
        public string? Email { get; set; }

        [DisplayName("IsSelected")]
        [DefaultValue(false)]
        public bool IsSelected { get; set; }

        [DisplayName("IsSelected_Thanks")]
        [DefaultValue(false)]
        public bool IsSelectedThanks { get; set; }

        [DisplayName("IsSelected_Letters")]
        [DefaultValue(false)]
        public bool IsSelectedLetters { get; set; }

        [DisplayName("Military")]
        [DefaultValue(0)]
        public int Military { get; set; }

        //---------------------------relationships
        public virtual ICollection<Career>? Careers { get; set; }
        public virtual ICollection<VacationTotal>? VacationTotals { get; set; }
        public virtual ICollection<Vacation>? Vacations { get; set; }
        public virtual ICollection<ConsultantTask>? ConsultantTasks { get; set; }
        public virtual ICollection<TrainingCourse>? TrainingCourses { get; set; }
        public virtual ICollection<Committee>? Committees { get; set; }
        public virtual ICollection<Deligation>? Deligations { get; set; }
        public virtual ICollection<Reward>? Rewards { get; set; }
        public virtual ICollection<Raise>? Raises { get; set; }
        public virtual ICollection<AddedService>? AddedServices { get; set; }
        public virtual ICollection<EducationCertificate>? EducationCertificates { get; set; }
        public virtual ICollection<AdministrativeAction>? AdministrativeActions { get; set; }
        public virtual ICollection<OfficialDocument>? OfficialDocuments { get; set; }
    }
}
