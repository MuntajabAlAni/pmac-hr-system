namespace Infrastructure.Queries;

public class VacationTypeQueries
{
    public const string FindAllQuery = """
        SELECT 
            Id, Name, IsConditional, IsCountedInBalance, BonusAffect, PromotionAffect
        FROM VacationType
        ORDER BY Name
        """;

    public const string FindByIdQuery = """
        SELECT 
            Id, Name, IsConditional, IsCountedInBalance, BonusAffect, PromotionAffect
        FROM VacationType
        WHERE Id = @Id
        """;

    public const string InsertQuery = """
        INSERT INTO VacationType (
            Id, Name, IsConditional, IsCountedInBalance, BonusAffect, PromotionAffect
        )
        VALUES (
            @Id, @Name, @IsConditional, @IsCountedInBalance, @BonusAffect, @PromotionAffect
        )
        """;

    public const string UpdateQuery = """
        UPDATE VacationType SET
            Name = @Name,
            IsConditional = @IsConditional,
            IsCountedInBalance = @IsCountedInBalance,
            BonusAffect = @BonusAffect,
            PromotionAffect = @PromotionAffect
        WHERE Id = @Id
        """;

    public const string DeleteQuery = """
        DELETE FROM VacationType WHERE Id = @Id
        """;
}
