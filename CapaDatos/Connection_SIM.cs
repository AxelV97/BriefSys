using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    class Connection_SIM
    {
        SqlConnection SQL_CONEXION;
        SqlCommand SQL_COMANDO;

        public SqlConnection GET_CONEXION()
        {
            return SQL_CONEXION;
        }

        public string connectionString()
        {
            string connString = "Data Source=SECTOR-8; Initial Catalog=BriefSys; User ID=sa; Integrated Security=False;Password=Reconnected.2020; MultipleActiveResultSets=True;";
            return connString;
        }

        public bool Conectar()
        {
            try
            {
                SQL_CONEXION = new SqlConnection();
                if (SQL_CONEXION.State.ToString().Equals("Open"))
                {
                    SQL_CONEXION.Close();
                }
                SQL_CONEXION.ConnectionString = connectionString();
                SQL_CONEXION.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Desconectar()
        {
            try
            {
                if (SQL_CONEXION.State.ToString().Equals("Closed"))
                {
                    SQL_CONEXION.Open();
                }
                SQL_CONEXION.Close();
            }
            catch (Exception)
            {

            }
        }

        public DataTable cargarDT(string qry)
        {
            DataTable dt = new DataTable();
            try
            {
                if (Conectar())
                {
                    SQL_COMANDO = new SqlCommand(qry, GET_CONEXION());
                    SQL_COMANDO.CommandTimeout = 0;
                    SqlDataAdapter da = new SqlDataAdapter(SQL_COMANDO);
                    da.Fill(dt);
                    Desconectar();
                }
            }
            catch (Exception)
            {
            }
            return dt;
        }
    }
}
