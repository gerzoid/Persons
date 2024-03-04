using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public abstract class DbServiceBase
    {
        private readonly IConfiguration _configuration;
        protected readonly SqlConnection _connection;

        protected DbServiceBase(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }
    }
}