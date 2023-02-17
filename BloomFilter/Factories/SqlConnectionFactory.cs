using BloomFilter.Interfaces.Factories;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BloomFilter.Factories
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public SqlConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection Connection()
            => new SqlConnection(_configuration.GetConnectionString("sqlConnectionString"));
    }
}
