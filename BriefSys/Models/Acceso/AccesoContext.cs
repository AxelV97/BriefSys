using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using BriefSys.Models.RH;

namespace BriefSys.Models.Acceso
{
    public class AccesoContext : DbContext
    {
        public AccesoContext() : base("BriefSys")
        {

        }
        public DbSet<Acceso_Usuario> Acceso_Usuarios { get; set; }
        public DbSet<Empleado_Detalle> EmpleadosDetalle { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}