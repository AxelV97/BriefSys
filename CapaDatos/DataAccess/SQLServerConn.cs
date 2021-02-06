using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataLayer.DataAccess
{
    class SQLServerConn
    {
        private SqlConnection SQL_CONEXION;
        public SqlCommand SQL_COMANDO;
        private string connectionstring;

        public SQLServerConn()
        {
            setConnectionString("SECTOR-8", "Briefsys", "Briefing", "Reconn.2020");
        }

        public void setConnectionString(string datasource, string catalog, string user, string pass)
        {
            this.connectionstring = @"Data Source=" + datasource + ";Initial Catalog=" + catalog + ";User ID=" + user + ";Password=" + pass + ";Persist Security Info=True; MultipleActiveResultSets=True";
        }

        public string getConnectionString()
        {
            return this.connectionstring;
        }

        public void SET_SQL_CONEXION()
        {
            this.SQL_CONEXION = new SqlConnection();
        }

        public SqlConnection GET_SQL_CONEXION()
        {
            return this.SQL_CONEXION;
        }

        public bool Conectar()
        {
            try
            {
                SET_SQL_CONEXION();
                if (GET_SQL_CONEXION().State.ToString().Equals("Open"))
                {
                    GET_SQL_CONEXION().Close();
                }
                GET_SQL_CONEXION().ConnectionString = getConnectionString();
                GET_SQL_CONEXION().Open();
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
                if (GET_SQL_CONEXION().State.Equals("Closed"))
                {
                    GET_SQL_CONEXION().Open();
                }
                GET_SQL_CONEXION().Close();
            }
            catch (Exception ex)
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
                    SQL_COMANDO = new SqlCommand(@qry, GET_SQL_CONEXION());
                    SQL_COMANDO.CommandTimeout = 0;
                    SqlDataAdapter da = new SqlDataAdapter(SQL_COMANDO);
                    da.Fill(dt);
                    Desconectar();
                }
            }
            catch (Exception ex)
            {
                Desconectar();
                throw;
            }
            return dt;
        }
    }
}
