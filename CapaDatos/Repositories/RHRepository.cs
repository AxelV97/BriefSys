using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DataAccess;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class RHRepository
    {
        DataSource objConexion = new DataSource();
        private ApplicationDbContext _db;

        public RHRepository()
        {
            _db = new ApplicationDbContext();
        }

        public List<Departamento> obtenerDepartamentos()
        {
            List<Departamento> ldepartamentos = new List<Departamento>();
            string qry = "select * from dbo.departamento where Estado <> 'C'";
            DataTable dt = new DataTable();
            dt = objConexion.cargarDT(qry);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Departamento departamento = new Departamento();
                    departamento.IdDepartamento = int.Parse(dt.Rows[i]["IdDepartamento"].ToString());
                    departamento.Clasificacion = dt.Rows[i]["Clasificacion"].ToString();
                    departamento.Descripcion = dt.Rows[i]["Descripcion"].ToString();
                    departamento.Estado = dt.Rows[i]["Estado"].ToString();
                    ldepartamentos.Add(departamento);
                }
            }
            return ldepartamentos;
        }

        public List<Departamento> obtenerDepartamentosEF()
        {
            var dbSetDepartamentos = _db.Departamentos;

            var departamentos = from dp in dbSetDepartamentos
                                where dp.Estado != "C"
                                select dp;

            return departamentos.ToList();
        }
    }
}
