namespace Infrastructure.Queries;

public class StoreEmployeeQueries
{
    public const string FindAllQuery = """
        SELECT Id, HREmployeeId, FullName, Directorate, Department, 
               DateOfEmployment, DateOfInitiation, Malak, Continuation
        FROM StoreEmployee
        ORDER BY FullName
        """;

    public const string FindByIdQuery = """
        SELECT Id, HREmployeeId, FullName, Directorate, Department, 
               DateOfEmployment, DateOfInitiation, Malak, Continuation
        FROM StoreEmployee
        WHERE Id = @Id
        """;

    public const string InsertQuery = """
        INSERT INTO StoreEmployee (Id, HREmployeeId, FullName, Directorate, Department, 
                                  DateOfEmployment, DateOfInitiation, Malak, Continuation)
        VALUES (@Id, @HREmployeeId, @FullName, @Directorate, @Department, 
                @DateOfEmployment, @DateOfInitiation, @Malak, @Continuation)
        """;

    public const string UpdateQuery = """
        UPDATE StoreEmployee SET
            HREmployeeId = @HREmployeeId,
            FullName = @FullName,
            Directorate = @Directorate,
            Department = @Department,
            DateOfEmployment = @DateOfEmployment,
            DateOfInitiation = @DateOfInitiation,
            Malak = @Malak,
            Continuation = @Continuation
        WHERE Id = @Id
        """;

    public const string DeleteQuery = """
        DELETE FROM StoreEmployee WHERE Id = @Id
        """;
}
