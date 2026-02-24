namespace Infrastructure.Queries;

public class AdministrativeActionTypeQueries
{
    public const string FindAllQuery = """
        SELECT 
            Id,
            Name,
            ImpactInDays,
            IsPenalty,
            RaiseAffected
        FROM Administrative_Action_Type
        ORDER BY Name
        """;

    public const string FindByIdQuery = """
        SELECT 
            Id,
            Name,
            ImpactInDays,
            IsPenalty,
            RaiseAffected
        FROM Administrative_Action_Type
        WHERE Id = @Id
        """;

    public const string InsertQuery = """
        INSERT INTO Administrative_Action_Type (
            Id, Name, ImpactInDays, IsPenalty, RaiseAffected
        )
        VALUES (
            @Id, @Name, @ImpactInDays, @IsPenalty, @RaiseAffected
        )
        """;

    public const string UpdateQuery = """
        UPDATE Administrative_Action_Type SET
            Name = @Name,
            ImpactInDays = @ImpactInDays,
            IsPenalty = @IsPenalty,
            RaiseAffected = @RaiseAffected
        WHERE Id = @Id
        """;

    public const string DeleteQuery = """
        DELETE FROM Administrative_Action_Type WHERE Id = @Id
        """;
}
