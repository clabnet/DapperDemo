using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.myTest
{
    class Program
    {
        // my postgres samples database
        public static readonly string connectionString = "Data Source=.;Initial Catalog=dvdrental;Integrated Security=True";
                
        public static SqlConnection GetOpenConnection(bool mars = false)
        {
            var cs = connectionString;
            if (mars)
            {
                SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder(cs);
                scsb.MultipleActiveResultSets = true;
                cs = scsb.ConnectionString;
            }
            var connection = new SqlConnection(cs);
            connection.Open();
            return connection;
        }
        public static SqlConnection GetClosedConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
