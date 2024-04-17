using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.RepoDb
{
    public abstract class DbServiceBase
    {
        private readonly IConfiguration _configuration;
        protected readonly SqlConnection _connection;

        protected DbServiceBase(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("PrimaryDbConnection");
            _connection = new SqlConnection(connectionString);
        }
    }
}