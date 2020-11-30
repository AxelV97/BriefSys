using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace BriefSys.Models.RH
{
    public class RHContext : DbContext
    {
        public RHContext() : base("BriefSys")
        {

        }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Puesto> Puestos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Empleado_Detalle> EmpleadosDetalle { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}