namespace Infrastructure.Queries;

public class EducationCertificateQueries
{
    public const string FindAllQuery = """
        SELECT 
            EC.Id,
            EC.EmployeeId,
            EC.CertificateId,
            EC.NumberOfMonths,
            EC.InstituteName,
            EC.CollegeName,
            EC.DepartmentName,
            EC.Major,
            EC.CertificateNumber,
            EC.OrderDate,
            EC.YearOfGraduate,
            EC.ApproveCertificateNumber,
            EC.ApproveCertificateDate,
            EC.CountryOfGraduate,
            EC.Sequence,
            EC.Average,
            EC.AffectRaise,
            EC.ConsiderationDate,
            EC.EducationNotes,
            EC.Running,
            EC.FilePath,
            E.Employee_F_Name + ' ' + E.Employee_L_Name AS EmployeeFullName,
            C.Name AS CertificateName
        FROM Education_Certificate EC
        LEFT JOIN Employee E ON EC.EmployeeId = E.Emp_Id
        LEFT JOIN Certificate C ON EC.CertificateId = C.Id
        ORDER BY EC.OrderDate DESC
        """;

    public const string FindByIdQuery = """
        SELECT 
            EC.Id,
            EC.EmployeeId,
            EC.CertificateId,
            EC.NumberOfMonths,
            EC.InstituteName,
            EC.CollegeName,
            EC.DepartmentName,
            EC.Major,
            EC.CertificateNumber,
            EC.OrderDate,
            EC.YearOfGraduate,
            EC.ApproveCertificateNumber,
            EC.ApproveCertificateDate,
            EC.CountryOfGraduate,
            EC.Sequence,
            EC.Average,
            EC.AffectRaise,
            EC.ConsiderationDate,
            EC.EducationNotes,
            EC.Running,
            EC.FilePath,
            E.Employee_F_Name + ' ' + E.Employee_L_Name AS EmployeeFullName,
            C.Name AS CertificateName
        FROM Education_Certificate EC
        LEFT JOIN Employee E ON EC.EmployeeId = E.Emp_Id
        LEFT JOIN Certificate C ON EC.CertificateId = C.Id
        WHERE EC.Id = @Id
        """;

    public const string InsertQuery = """
        INSERT INTO Education_Certificate (
            Id, EmployeeId, CertificateId, NumberOfMonths, InstituteName, 
            CollegeName, DepartmentName, Major, CertificateNumber, OrderDate, 
            YearOfGraduate, ApproveCertificateNumber, ApproveCertificateDate, 
            CountryOfGraduate, Sequence, Average, AffectRaise, ConsiderationDate, 
            EducationNotes, Running, FilePath
        )
        VALUES (
            @Id, @EmployeeId, @CertificateId, @NumberOfMonths, @InstituteName, 
            @CollegeName, @DepartmentName, @Major, @CertificateNumber, @OrderDate, 
            @YearOfGraduate, @ApproveCertificateNumber, @ApproveCertificateDate, 
            @CountryOfGraduate, @Sequence, @Average, @AffectRaise, @ConsiderationDate, 
            @EducationNotes, @Running, @FilePath
        )
        """;

    public const string UpdateQuery = """
        UPDATE Education_Certificate SET
            EmployeeId = @EmployeeId,
            CertificateId = @CertificateId,
            NumberOfMonths = @NumberOfMonths,
            InstituteName = @InstituteName,
            CollegeName = @CollegeName,
            DepartmentName = @DepartmentName,
            Major = @Major,
            CertificateNumber = @CertificateNumber,
            OrderDate = @OrderDate,
            YearOfGraduate = @YearOfGraduate,
            ApproveCertificateNumber = @ApproveCertificateNumber,
            ApproveCertificateDate = @ApproveCertificateDate,
            CountryOfGraduate = @CountryOfGraduate,
            Sequence = @Sequence,
            Average = @Average,
            AffectRaise = @AffectRaise,
            ConsiderationDate = @ConsiderationDate,
            EducationNotes = @EducationNotes,
            Running = @Running,
            FilePath = @FilePath
        WHERE Id = @Id
        """;

    public const string DeleteQuery = """
        DELETE FROM Education_Certificate WHERE Id = @Id
        """;
}
