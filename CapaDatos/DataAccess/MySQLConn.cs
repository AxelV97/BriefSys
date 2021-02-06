using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DataLayer.DataAccess
{
    class MySQLConn
    {
        private MySqlConnection connection;

        private string server, database, uid, password;
        public MySQLConn()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "localhost";
            database = "";
            string connectionString = @"";
        }
    }
}
