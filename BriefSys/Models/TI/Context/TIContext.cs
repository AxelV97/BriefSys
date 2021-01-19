using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using BriefSys.Models.TI.Tickets;

namespace BriefSys.Models.TI.Context
{
    public class TIContext : DbContext
    {
        public TIContext() : base("BriefSys")
        {

        }
        public DbSet<ServiceDesk> Tickets { get; set; }
        public DbSet<ServiceDesk_Detalle> Tickets_Detalle { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}