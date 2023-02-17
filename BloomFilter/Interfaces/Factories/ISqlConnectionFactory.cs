using System.Data;

namespace BloomFilter.Interfaces.Factories
{
    public interface ISqlConnectionFactory
    {
        IDbConnection Connection();
    }
}
