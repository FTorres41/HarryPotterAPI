using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.IO;

namespace HarryPotter.Data.DapperORM.Class
{
    public class BaseRepository
    {
        public static IConfigurationRoot Configuration { get; set; }

        public SqlConnection GetSqlConnection(bool open = true,
            bool convertZeroDatetime = false, bool allowZeroDatetime = false)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            var cs = Configuration["Logging:AppSettings:SqlConnectionString"];
            var conn = new SqlConnection(cs);
            if (open) conn.Open();

            return conn;
        }
    }
}