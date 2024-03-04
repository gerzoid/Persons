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
        protected readonly SqlConnection _connection;

        protected DbServiceBase(SqlConnection connection)
        {
            _connection = connection;
        }
    }
}