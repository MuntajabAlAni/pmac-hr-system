namespace Infrastructure.Queries;

public class LogFileQueries
{
    public const string FindAllQuery = """
        SELECT Id, UserName, EntryTime, EntryType, EntryTable, RecordId, NotificationString, EmployeeName, Link, Military 
        FROM Log_File 
        ORDER BY EntryTime DESC
        """;

    public const string FindByIdQuery = """
        SELECT Id, UserName, EntryTime, EntryType, EntryTable, RecordId, NotificationString, EmployeeName, Link, Military 
        FROM Log_File 
        WHERE Id = @Id
        """;

    public const string InsertQuery = """
        INSERT INTO Log_File (
            Id, UserName, EntryTime, EntryType, EntryTable, RecordId, 
            NotificationString, EmployeeName, Link, Military
        ) VALUES (
            @Id, @UserName, @EntryTime, @EntryType, @EntryTable, @RecordId, 
            @NotificationString, @EmployeeName, @Link, @Military
        )
        """;
}
