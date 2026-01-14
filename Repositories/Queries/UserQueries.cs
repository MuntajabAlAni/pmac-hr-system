namespace Repositories.Queries;

public class UserQueries
{
    public const string InsertQuery = """
                                      INSERT INTO Users (FullName, RoleId, PhoneNumber, Specialty, Email, Password, AddedByUserId, ProviderId)
                                        OUTPUT inserted.Id VALUES (@FullName, @RoleId, @PhoneNumber, @Specialty, @Email, @Password, @AddedByUserId, @ProviderId)
                                      """;

    public const string UpdateByIdQuery = """
                                          UPDATE Users SET
                                               FullName = @FullName,
                                               RoleId = @RoleId,
                                               PhoneNumber = @PhoneNumber,
                                               Specialty = @Specialty,
                                               Email = @Email,
                                               ProviderId = @ProviderId
                                               WHERE Id = @Id
                                          """;

    public const string UpdateLoggedInByIdQuery = """
                                                  UPDATE Users SET
                                                       FullName = @FullName,
                                                       PhoneNumber = @PhoneNumber,
                                                       Specialty = @Specialty,
                                                       Email = @Email
                                                       WHERE Id = @Id
                                                  """;

    public const string ByEmailOrIdQuery = """
                                           SELECT U.Id, U.FullName, U.RoleId, U.PhoneNumber, U.Specialty, U.Email,
                                                  U.Password, U.RefreshToken, U.RefreshTokenExpiryTime, U.AddedByUserId,
                                                  AU.FullName AS AddedByUsername, U.ProviderId, U.RoleId,
                                                  U.RecordDate, U.FcmToken
                                           FROM Users U
                                           LEFT JOIN Users AU ON U.AddedByUserId = AU.Id
                                           WHERE U.IsDeleted = 0 AND ((U.Email = @Email AND @Id IS NULL) OR U.Id = @Id)
                                           """;

    public const string UserAdditionalPermissionsByIdQuery = """
                                                             SELECT UP.Permission
                                                              FROM UserAdditionalPermissions UP
                                                              WHERE UP.UserId = @Id
                                                             """;

    public const string InsertUserAdditionalPermissionsQuery =
        "INSERT INTO UserAdditionalPermissions (UserId, Permission) VALUES (@UserId, @Permission)";

    public const string DeleteUserAdditionalPermissionsByIdQuery =
        "DELETE FROM UserAdditionalPermissions  WHERE UserId = @Id";

    public const string UpdatePasswordByIdQuery = "UPDATE Users SET Password = @NewPassword WHERE Id = @Id;";
    public const string DeleteByIdQuery = "UPDATE Users SET IsDeleted = 1 WHERE Id = @Id";

    public const string UpdateRefreshTokenByIdQuery =
        "UPDATE Users SET RefreshToken = @refreshToken, RefreshTokenExpiryTime = @refreshTokenExpiryTime WHERE Id = @id;";

    public const string CountByParametersQuery = """
                                                 SELECT COUNT(U.Id)
                                                          FROM Users U
                                                          WHERE U.IsDeleted = 0
                                                            AND (@FullName IS NULL OR U.FullName LIKE '%' + @FullName + '%')
                                                            AND (@PhoneNumber IS NULL OR U.PhoneNumber LIKE '%' + @PhoneNumber + '%')
                                                            AND (@Email IS NULL OR U.Email LIKE '%' + @Email + '%')
                                                            AND (@RoleId IS NULL OR U.RoleId = @RoleId)
                                                            AND (@ProviderId IS NULL OR U.ProviderId = @ProviderId)
                                                            AND (@AddedByUserId IS NULL OR U.AddedByUserId = @AddedByUserId)
                                                 """;

    public const string ByParametersQuery = """
                                            SELECT U.Id, U.FullName, U.PhoneNumber, U.Email, U.Specialty, U.RecordDate, U.ProviderId, U.RoleId
                                                     FROM Users U
                                                     WHERE U.IsDeleted = 0
                                                       AND (@FullName IS NULL OR U.FullName LIKE '%' + @FullName + '%')
                                                       AND (@PhoneNumber IS NULL OR U.PhoneNumber LIKE '%' + @PhoneNumber + '%')
                                                       AND (@Email IS NULL OR U.Email LIKE '%' + @Email + '%')
                                                       AND (@RoleId IS NULL OR U.RoleId = @RoleId)
                                                       AND (@ProviderId IS NULL OR U.ProviderId = @ProviderId)
                                                       AND (@AddedByUserId IS NULL OR U.AddedByUserId = @AddedByUserId)
                                             ORDER BY U.RecordDate DESC
                                             OFFSET @Skip ROWS FETCH NEXT @PageSize ROWS ONLY;
                                            """;

    public const string AllRolesQuery = "SELECT R.Id, R.Description FROM Roles R";

    public const string RoleByDescriptionOrIdQuery = """
                                                     SELECT R.Id, R.Description FROM Roles R
                                                      WHERE (R.Description = @Description AND @Id IS NULL) OR R.Id = @Id
                                                     """;

    public const string RolePermissionsByIdQuery = """
                                                   SELECT RP.Permission
                                                    FROM RolePermissions RP 
                                                    WHERE RP.RoleId = @Id
                                                   """;

    public const string InsertRoleQuery = "INSERT INTO Roles (Description) OUTPUT inserted.Id VALUES (@Description)";

    public const string InsertRolePermissionsQuery =
        "INSERT INTO RolePermissions (RoleId, Permission) VALUES (@RoleId, @Permission)";

    public const string UpdateRoleByIdQuery = """
                                              UPDATE Roles SET
                                                   Description = @Description
                                                   WHERE Id = @Id
                                              """;

    public const string DeleteRolePermissionsByIdQuery = "DELETE FROM RolePermissions  WHERE RoleId = @Id";
    public const string DeleteRoleByIdQuery = "DELETE FROM Roles  WHERE Id = @Id";

    public const string FcmTokenByIdQuery = "SELECT FcmToken FROM  Users WHERE Id = @Id AND IsDeleted = 0";
    public const string UpdateFcmTokenQuery = "UPDATE Users SET FcmToken = @FcmToken WHERE Id = @Id;";
    public const string UpdateAccessTokenQuery = "UPDATE Users SET AccessToken = @AccessToken WHERE Id = @Id";
    public const string AccessTokenByIdQuery = "SELECT AccessToken FROM  Users WHERE Id = @Id AND IsDeleted = 0";
    public const string AllByProviderIdQuery = "SELECT Id FROM Users WHERE ProviderId = @ProviderId AND IsDeleted = 0";

    public const string LocationsByUserIdQuery = """
                                                 SELECT UL.Id, UL.UserId, U.FullName AS UserName, UL.Title, UL.Description, UL.Longitude, UL.Latitude, UL.RecordDate
                                                  FROM UserLocations UL
                                                  LEFT JOIN Users U ON UL.UserId = U.Id
                                                  WHERE UL.UserId = @UserId AND UL.IsDeleted = 0
                                                 """;

    public const string LocationByIdQuery = """
                                            SELECT UL.Id, UL.UserId, U.FullName AS UserName, UL.Title, UL.Description, UL.Longitude, UL.Latitude, UL.RecordDate
                                             FROM UserLocations UL
                                             LEFT JOIN Users U ON UL.UserId = U.Id
                                             WHERE UL.Id = @Id AND UL.IsDeleted = 0
                                            """;

    public const string InsertLocationQuery = """
                                              INSERT INTO UserLocations (UserId, Title, Description, Longitude, Latitude)
                                               OUTPUT inserted.Id VALUES (@UserId, @Title, @Description, @Longitude, @Latitude)
                                              """;

    public const string UpdateLocationByIdQuery = """
                                              UPDATE UserLocations SET
                                               Title = @Title,
                                               Description = @Description,
                                               Longitude = @Longitude,
                                               Latitude = @Latitude
                                               WHERE Id = @Id
                                              """;

    public const string DeleteLocationByIdQuery = "UPDATE UserLocations SET IsDeleted = 1 WHERE Id = @Id";
}