using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

using System.Data;
using System.Data.SqlClient;

namespace SensitiveEats.DataAccess
{
    public class SensitiveEatsDbContext
    {
        private readonly SensitiveEatsDbModel _options;
        public SensitiveEatsDbContext(IOptions<SensitiveEatsDbModel> options)
        {
            _options = options.Value;
 
        }
        public IDbConnection CreateConnection()
            => new SqlConnection("data source=127.0.0.1,1433;initial catalog=vida;user id=sa;password=#Vidarostami98;TrustServerCertificate=True");
        //az ioption bezar
    }

}
