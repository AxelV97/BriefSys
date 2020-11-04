using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CSD_Conexion
    {
        public SqlConnection SQL_CONEXION;
        static SqlCommand SQL_COMANDO;

        public SqlConnection GET_SQL_CONEXION()
        {
            return SQL_CONEXION;
        }

        string connectionString = "";
        public string ConnectionString()
        {
            connectionString = "Data Source=SECTOR-8; Initial Catalog=BriefSys; User ID=sa; Password=Reconnected.2020;";
            return connectionString;
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
                SQL_CONEXION.ConnectionString = ConnectionString();
                SQL_CONEXION.Open();
                return true;
            }
            catch (Exception ex)
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
            catch (Exception ex)
            {

            }
        }

        public DataTable CargarDT(string qry)
        {
            DataTable dt = new DataTable();
            if (Conectar())
            {
                SQL_COMANDO = new SqlCommand(qry, GET_SQL_CONEXION());
                SQL_COMANDO.CommandTimeout = 0;
                SqlDataAdapter da = new SqlDataAdapter(SQL_COMANDO);
                da.Fill(dt);
                Desconectar();
            }
            return dt;
        }
    }
}
