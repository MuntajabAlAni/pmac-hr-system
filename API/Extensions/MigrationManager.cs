using FluentMigrator.Runner;
using Domain.Interfaces;
using API.Migrations;

namespace API.Extensions
{
    public static class MigrationManager
    {
        public static void MigrateDatabase(this WebApplication app,
            ILoggerManager logger, IConfiguration configuration)
        {
            using var scope = app.Services.CreateScope();
            var databaseService = scope.ServiceProvider
                .GetRequiredService<Database>();
            var migrationService = scope.ServiceProvider
                .GetRequiredService<IMigrationRunner>();

            try
            {
                var connectionString = configuration
                    .GetConnectionString("sqlConnection");

                var parts = connectionString?.ToLower().Split(';');

                var databasePart = parts?.FirstOrDefault(p => p.Trim().StartsWith("database="));
                var database = databasePart?.Split('=')[1];

                if (database is null)
                    throw new NullReferenceException();

                databaseService.CreateDatabase(database);
                migrationService.ListMigrations();
                migrationService.MigrateUp();
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception occurred during the database creation: {ex}");
                throw;
            }
        }
    }
}