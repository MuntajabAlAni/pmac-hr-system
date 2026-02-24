namespace Infrastructure.Queries;

public class EmployeeQueries
{
    public const string FindByIdQuery = """
        SELECT E.Emp_Id AS Id, E.Employee_F_Name AS FullName, E.Employee_First_Name AS FirstName, 
               E.Employee_Second_Name AS SecondName, E.Employee_Third_Name AS ThirdName, 
               E.Employee_Forth_Name AS FourthName, E.Employee_Last_Name AS LastName, 
               E.Mother_Name AS MotherName, E.Gender_Id AS GenderId, E.Birth_Date AS BirthDate, 
               E.Phone_No AS PhoneNumber, E.Email, E.Civil_Id_No AS CivilIdNumber, 
               E.Nat_Card_No AS NationalCardNumber, E.Address AS FullAddress, 
               E.Marital_Status AS MaritalStatusId, E.IsDeleted,
               E.Store_Emp_Id AS StoreEmployeeId, E.Blood_Group AS BloodGroup, 
               E.Nationality, E.Religion, E.Place_Of_Birth AS PlaceOfBirth, 
               E.Number_Of_Children AS NumberOfChildren, E.Spouse_Name AS SpouseName, 
               E.Spouse_Job AS SpouseJob, E.Record_Number AS RecordNumber, 
               E.Page_Number AS PageNumber, E.Publisher, E.Date_Of_Issuance AS DateOfIssuance, 
               E.National_Card_Issuance_Date AS NationalCardIssuanceDate, 
               E.Certificate_Number AS CertificateNumber, E.Pocket_Number AS PocketNumber, 
               E.Certificate_Publisher AS CertificatePublisher, 
               E.Certificate_Issuance_Date AS CertificateIssuanceDate, 
               E.Information_Office_Name AS InformationOfficeName, 
               E.Housing_Card_Number AS HousingCardNumber, 
               E.Housing_Card_Issuance_Date AS HousingCardIssuanceDate, 
               E.Supplying_Card_Number AS SupplyingCardNumber, 
               E.Supply_Center_Name AS SupplyCenterName, 
               E.Supply_Center_Number AS SupplyCenterNumber, E.Supply_Notes AS SupplyNotes, 
               E.File_Path AS FilePath, E.Profile_Picture AS ProfilePicture, 
               E.IsSelected, E.IsSelected_Thanks AS IsSelectedThanks, 
               E.IsSelected_Letters AS IsSelectedLetters, E.Military,
               G.Gender_Name, MS.Marital_Status_Name
        FROM Employee E
        LEFT JOIN Gender G ON E.Gender_Id = G.Gender_Id
        LEFT JOIN Marital_Status MS ON E.Marital_Status = MS.Marital_Status_Id
        WHERE E.Emp_Id = @Id
        """;

    public const string FindAllQuery = """
        SELECT E.Emp_Id AS Id, E.Employee_F_Name AS FullName, E.Employee_National_Num AS NationalNum, 
               E.Phone_No AS PhoneNumber, E.Email, E.Gender_Id AS GenderId, G.Gender_Name, 
               E.Birth_Date AS BirthDate, E.Marital_Status AS MaritalStatusId, MS.Marital_Status_Name
        FROM Employee E
        LEFT JOIN Gender G ON E.Gender_Id = G.Gender_Id
        LEFT JOIN Marital_Status MS ON E.Marital_Status = MS.Marital_Status_Id
        WHERE E.IsDeleted = 0
        ORDER BY E.Employee_F_Name
        OFFSET @Skip ROWS FETCH NEXT @PageSize ROWS ONLY
        """;

    public const string CountQuery = """
        SELECT COUNT(*) FROM Employee WHERE IsDeleted = 0
        """;

    public const string SearchQuery = """
        SELECT E.Emp_Id AS Id, E.Employee_F_Name AS FullName, E.Phone_No AS PhoneNumber, E.Email
        FROM Employee E
        WHERE E.IsDeleted = 0 AND (
            E.Employee_F_Name LIKE '%' + @SearchTerm + '%' OR
            E.Phone_No LIKE '%' + @SearchTerm + '%' OR
            E.Email LIKE '%' + @SearchTerm + '%'
        )
        ORDER BY E.Employee_F_Name
        OFFSET @Skip ROWS FETCH NEXT @PageSize ROWS ONLY
        """;

    public const string InsertQuery = """
        INSERT INTO Employee (
            Emp_Id, Employee_F_Name, Employee_First_Name, Employee_Second_Name,
            Employee_Third_Name, Employee_Forth_Name, Employee_Last_Name,
            Mother_Name, Gender_Id, Birth_Date, Phone_No, Email,
            Civil_Id_No, Nat_Card_No, Address, Marital_Status,
            Store_Emp_Id, Blood_Group, Nationality, Religion, Place_Of_Birth,
            Number_Of_Children, Spouse_Name, Spouse_Job, Record_Number,
            Page_Number, Publisher, Date_Of_Issuance, National_Card_Issuance_Date,
            Certificate_Number, Pocket_Number, Certificate_Publisher,
            Certificate_Issuance_Date, Information_Office_Name, Housing_Card_Number,
            Housing_Card_Issuance_Date, Supplying_Card_Number, Supply_Center_Name,
            Supply_Center_Number, Supply_Notes, File_Path, Profile_Picture,
            IsSelected, IsSelected_Thanks, IsSelected_Letters, Military
        ) VALUES (
            @Id, @FullName, @FirstName, @SecondName,
            @ThirdName, @FourthName, @LastName,
            @MotherName, @GenderId, @BirthDate, @PhoneNumber, @Email,
            @CivilIdNumber, @NationalCardNumber, @FullAddress, @MaritalStatusId,
            @StoreEmployeeId, @BloodGroup, @Nationality, @Religion, @PlaceOfBirth,
            @NumberOfChildren, @SpouseName, @SpouseJob, @RecordNumber,
            @PageNumber, @Publisher, @DateOfIssuance, @NationalCardIssuanceDate,
            @CertificateNumber, @PocketNumber, @CertificatePublisher,
            @CertificateIssuanceDate, @InformationOfficeName, @HousingCardNumber,
            @HousingCardIssuanceDate, @SupplyingCardNumber, @SupplyCenterName,
            @SupplyCenterNumber, @SupplyNotes, @FilePath, @ProfilePicture,
            @IsSelected, @IsSelectedThanks, @IsSelectedLetters, @Military
        )
        """;

    public const string UpdateQuery = """
        UPDATE Employee SET
            Employee_F_Name = @FullName,
            Employee_First_Name = @FirstName,
            Employee_Second_Name = @SecondName,
            Employee_Third_Name = @ThirdName,
            Employee_Forth_Name = @FourthName,
            Employee_Last_Name = @LastName,
            Mother_Name = @MotherName,
            Gender_Id = @GenderId,
            Birth_Date = @BirthDate,
            Phone_No = @PhoneNumber,
            Email = @Email,
            Civil_Id_No = @CivilIdNumber,
            Nat_Card_No = @NationalCardNumber,
            Address = @FullAddress,
            Marital_Status = @MaritalStatusId,
            Store_Emp_Id = @StoreEmployeeId,
            Blood_Group = @BloodGroup,
            Nationality = @Nationality,
            Religion = @Religion,
            Place_Of_Birth = @PlaceOfBirth,
            Number_Of_Children = @NumberOfChildren,
            Spouse_Name = @SpouseName,
            Spouse_Job = @SpouseJob,
            Record_Number = @RecordNumber,
            Page_Number = @PageNumber,
            Publisher = @Publisher,
            Date_Of_Issuance = @DateOfIssuance,
            National_Card_Issuance_Date = @NationalCardIssuanceDate,
            Certificate_Number = @CertificateNumber,
            Pocket_Number = @PocketNumber,
            Certificate_Publisher = @CertificatePublisher,
            Certificate_Issuance_Date = @CertificateIssuanceDate,
            Information_Office_Name = @InformationOfficeName,
            Housing_Card_Number = @HousingCardNumber,
            Housing_Card_Issuance_Date = @HousingCardIssuanceDate,
            Supplying_Card_Number = @SupplyingCardNumber,
            Supply_Center_Name = @SupplyCenterName,
            Supply_Center_Number = @SupplyCenterNumber,
            Supply_Notes = @SupplyNotes,
            File_Path = @FilePath,
            Profile_Picture = @ProfilePicture,
            IsSelected = @IsSelected,
            IsSelected_Thanks = @IsSelectedThanks,
            IsSelected_Letters = @IsSelectedLetters,
            Military = @Military
        WHERE Emp_Id = @Id
        """;

    public const string DeleteQuery = """
        UPDATE Employee SET IsDeleted = 1 WHERE Emp_Id = @Id
        """;
}
