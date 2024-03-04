using RepoDb;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public class RepoDbContext : DbServiceBase
    {
        public RepoDbContext(SqlConnection connection) : base(connection)
        {
        }

        public IEnumerable<T> Query<T>(string query) where T : class {
            return _connection.Query<T>(query);
        }
    }
}
