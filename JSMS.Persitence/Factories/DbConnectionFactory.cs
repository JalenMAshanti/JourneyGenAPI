using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace JSMS.Persitence.Factories
{
    public class DbConnectionFactory
    {
        private readonly IDbConnection conn;
        public DbConnectionFactory()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string? connString = config.GetConnectionString("MySqlConnection");

            conn = new MySqlConnection(connString);
        }

        public IDbConnection GetConnection() { return conn; }
    }
}
