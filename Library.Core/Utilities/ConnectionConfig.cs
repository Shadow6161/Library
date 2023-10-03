using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Utilities
{
    public abstract class ConnectionConfig
    {
        public string ConnectionString { get; set; } = CoreConfig.GetConnectionString("Default");
        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(ConnectionString);
            }
        }
    }
}
