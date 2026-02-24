namespace Infrastructure.Queries;

public class VacationTypeQueries
{
    public const string FindAllQuery = """
        SELECT 
            Vacation_Type_Id AS Id,
            Vacation_Type_Name AS Name,
            Is_Condition AS IsCondition,
            Rsed,
            RaiseAffected
        FROM Vacation_Type
        ORDER BY Vacation_Type_Name
        """;

    public const string FindByIdQuery = """
        SELECT 
            Vacation_Type_Id AS Id,
            Vacation_Type_Name AS Name,
            Is_Condition AS IsCondition,
            Rsed,
            RaiseAffected
        FROM Vacation_Type
        WHERE Vacation_Type_Id = @Id
        """;

    public const string InsertQuery = """
        INSERT INTO Vacation_Type (
            Vacation_Type_Id, Vacation_Type_Name, Is_Condition, Rsed, RaiseAffected
        )
        VALUES (
            @Id, @Name, @IsCondition, @Rsed, @RaiseAffected
        )
        """;

    public const string UpdateQuery = """
        UPDATE Vacation_Type SET
            Vacation_Type_Name = @Name,
            Is_Condition = @IsCondition,
            Rsed = @Rsed,
            RaiseAffected = @RaiseAffected
        WHERE Vacation_Type_Id = @Id
        """;

    public const string DeleteQuery = """
        DELETE FROM Vacation_Type WHERE Vacation_Type_Id = @Id
        """;
}
