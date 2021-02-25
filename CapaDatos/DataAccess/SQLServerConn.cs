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
        private SqlCommand SQL_COMANDO;
        public string connectionstring;

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

        public void setSQL_CONEXION()
        {
            this.SQL_CONEXION = new SqlConnection();
        }

        public SqlConnection getSQL_CONEXION()
        {
            return this.SQL_CONEXION;
        }

        public void setSQL_COMANDO(string qry)
        {
            this.SQL_COMANDO = new SqlCommand(qry, getSQL_CONEXION());
            this.SQL_COMANDO.CommandTimeout = 0;
        }
        public SqlCommand getSQL_COMANDO()
        {
            return this.SQL_COMANDO;
        }

        public bool Conectar()
        {
            try
            {
                setSQL_CONEXION();
                if (getSQL_CONEXION().State.ToString().Equals("Open"))
                {
                    getSQL_CONEXION().Close();
                }
                getSQL_CONEXION().ConnectionString = getConnectionString();
                getSQL_CONEXION().Open();
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
                if (getSQL_CONEXION().State.Equals("Closed"))
                {
                    getSQL_CONEXION().Open();
                }
                getSQL_CONEXION().Close();
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
                using (SQL_CONEXION = new SqlConnection(getConnectionString()))
                {
                    using (SQL_COMANDO = new SqlCommand(@qry, SQL_CONEXION))
                    {
                        SQL_COMANDO.CommandTimeout = 0;
                        SqlDataAdapter da = new SqlDataAdapter(SQL_COMANDO);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }
        public DataSet Select(string qry, string tabla)
        {
            DataSet dataSet = new DataSet();
            try
            {
                if (Conectar())
                {
                    setSQL_COMANDO(qry);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(this.getSQL_COMANDO());
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
