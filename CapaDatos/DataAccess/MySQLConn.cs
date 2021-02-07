using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DataLayer.DataAccess
{
    public class MySQLConn
    {
        private MySqlConnection connection;

        private string server, database, uid, password;

        public MySQLConn()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "MYSQL5042.site4now.net";
            database = "db_a6f156_briefy";
            uid = "a6f156_briefy";
            password = "Reconn.2020";
            string connectionString;
            connectionString = @"SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        private bool Conectar()
        {
            try
            {
                if (connection.State.ToString().Equals("Open"))
                {
                    connection.Close();
                }
                connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool Desconectar()
        {
            try
            {
                if (connection.State.ToString().Equals("Closed"))
                {
                    connection.Open();
                }
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int ExecQuery(string qry)
        {
            int records = 0;
            try
            {
                if (Conectar())
                {
                    MySqlCommand cmd = new MySqlCommand(@qry, connection);
                    cmd.CommandTimeout = 0;
                    records = cmd.ExecuteNonQuery();
                    Desconectar();
                    return records;
                }
            }
            catch (Exception ex)
            {

            }
            return records;
        }

        public int Count()
        {
            int count = 0;
            return count;
        }

        public DataSet Select(string qry, string tabla)
        {
            DataSet dataSet = new DataSet();
            try
            {
                if (Conectar())
                {
                    MySqlCommand cmd = new MySqlCommand(@qry, connection);
                    cmd.CommandTimeout = 0;

                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    dataAdapter.Fill(dataSet, tabla);
                }
            }
            catch (Exception ex)
            {

            }
            return dataSet;
        }
    }
}
