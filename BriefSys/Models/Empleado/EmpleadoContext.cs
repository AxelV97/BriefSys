using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace BriefSys.Models.Empleado
{
    public class EmpleadoContext : DbContext
    {
        public EmpleadoContext() : base("BriefSys")
        {

        }
        public DbSet<EmpleadoDetalle> empleados { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}