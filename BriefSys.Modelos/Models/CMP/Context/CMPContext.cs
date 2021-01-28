using BriefSys.Models.CMP.Ordenes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace BriefSys.Models.CMP.Context
{
    public class CMPContext : DbContext
    {
        public CMPContext() : base("BriefSys")
        {

        }

        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Orden_Detalle> Ordenes_Detalle { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("Orden");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}