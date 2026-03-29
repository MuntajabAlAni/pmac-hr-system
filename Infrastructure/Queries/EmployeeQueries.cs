namespace Infrastructure.Queries;

public class EmployeeQueries
{
    public const string FindByIdQuery = """
        SELECT E.Emp_Id AS Id, E.EmployeeNumber, E.ArchiveNumber,
               E.Status, E.SpecialEmpStatus,
               E.HireDate, E.HireBookNumber, E.HireBookDate, E.HireBookFilePath,
               E.StartWorkDate, E.StartWorkBookDate, E.StartWorkBookFilePath,
               E.FirstName, E.SecondName, E.ThirdName, E.FourthName, E.LastName,
               E.SureName, E.MotherName, E.FullNameEnglish,
               E.Gender, E.Religion, E.Ethnicity, E.BloodGroup, E.BirthDate,
               E.MaritalStatus, E.PhoneNumber, E.Email
        FROM Employee E
        WHERE E.Emp_Id = @Id
        """;

    public const string FindAllQuery = """
        SELECT E.Emp_Id AS Id, E.EmployeeNumber, E.ArchiveNumber,
               E.FirstName, E.SecondName, E.ThirdName, E.FourthName, E.LastName,
               E.PhoneNumber, E.Email, E.Gender, E.Status, E.BirthDate, E.HireDate
        FROM Employee E
        WHERE E.IsDeleted = 0
        ORDER BY E.FirstName
        OFFSET @Skip ROWS FETCH NEXT @PageSize ROWS ONLY
        """;

    public const string CountQuery = """
        SELECT COUNT(*) FROM Employee WHERE IsDeleted = 0
        """;

    public const string SearchQuery = """
        SELECT E.Emp_Id AS Id, E.EmployeeNumber, E.ArchiveNumber,
               E.FirstName, E.SecondName, E.ThirdName, E.FourthName, E.LastName,
               E.PhoneNumber, E.Email, E.Gender, E.Status, E.BirthDate, E.HireDate
        FROM Employee E
        WHERE E.IsDeleted = 0 AND (
            E.FirstName LIKE '%' + @SearchTerm + '%' OR
            E.EmployeeNumber LIKE '%' + @SearchTerm + '%' OR
            E.PhoneNumber LIKE '%' + @SearchTerm + '%' OR
            E.Email LIKE '%' + @SearchTerm + '%'
        )
        ORDER BY E.FirstName
        OFFSET @Skip ROWS FETCH NEXT @PageSize ROWS ONLY
        """;

    public const string InsertQuery = """
        INSERT INTO Employee (
            Emp_Id, EmployeeNumber, ArchiveNumber, Status, SpecialEmpStatus,
            HireDate, HireBookNumber, HireBookDate, HireBookFilePath,
            StartWorkDate, StartWorkBookDate, StartWorkBookFilePath,
            FirstName, SecondName, ThirdName, FourthName, LastName,
            SureName, MotherName, FullNameEnglish,
            Gender, Religion, Ethnicity, BloodGroup, BirthDate,
            MaritalStatus, PhoneNumber, Email
        ) VALUES (
            @Id, @EmployeeNumber, @ArchiveNumber, @Status, @SpecialEmpStatus,
            @HireDate, @HireBookNumber, @HireBookDate, @HireBookFilePath,
            @StartWorkDate, @StartWorkBookDate, @StartWorkBookFilePath,
            @FirstName, @SecondName, @ThirdName, @FourthName, @LastName,
            @SureName, @MotherName, @FullNameEnglish,
            @Gender, @Religion, @Ethnicity, @BloodGroup, @BirthDate,
            @MaritalStatus, @PhoneNumber, @Email
        )
        """;

    public const string UpdateQuery = """
        UPDATE Employee SET
            EmployeeNumber = @EmployeeNumber,
            ArchiveNumber = @ArchiveNumber,
            Status = @Status,
            SpecialEmpStatus = @SpecialEmpStatus,
            HireDate = @HireDate,
            HireBookNumber = @HireBookNumber,
            HireBookDate = @HireBookDate,
            HireBookFilePath = @HireBookFilePath,
            StartWorkDate = @StartWorkDate,
            StartWorkBookDate = @StartWorkBookDate,
            StartWorkBookFilePath = @StartWorkBookFilePath,
            FirstName = @FirstName,
            SecondName = @SecondName,
            ThirdName = @ThirdName,
            FourthName = @FourthName,
            LastName = @LastName,
            SureName = @SureName,
            MotherName = @MotherName,
            FullNameEnglish = @FullNameEnglish,
            Gender = @Gender,
            Religion = @Religion,
            Ethnicity = @Ethnicity,
            BloodGroup = @BloodGroup,
            BirthDate = @BirthDate,
            MaritalStatus = @MaritalStatus,
            PhoneNumber = @PhoneNumber,
            Email = @Email
        WHERE Emp_Id = @Id
        """;

    public const string DeleteQuery = """
        UPDATE Employee SET IsDeleted = 1 WHERE Emp_Id = @Id
        """;
}
