using Microsoft.Extensions.Configuration;
using RepoDb;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.RepoDb
{
    public class RepoDbContext : DbServiceBase
    {
        public RepoDbContext(IConfiguration configuration) : base(configuration)
        {
        }

        public IEnumerable<T> Query<T>(string query) where T : class
        {
            return _connection.Query<T>(query);
        }

        public IEnumerable<T> QueryAll<T>() where T : class
        {
            return _connection.QueryAll<T>();
        }

    }
}
