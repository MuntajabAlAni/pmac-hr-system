using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Repositories
{
    public class DapperContext(IConfiguration configuration)
    {
        public IDbConnection CreateConnection()
            => new SqlConnection(configuration
                .GetConnectionString("sqlConnection"));

        public IDbConnection CreateMasterConnection()
            => new SqlConnection(configuration
                .GetConnectionString("masterConnection"));
    }
}