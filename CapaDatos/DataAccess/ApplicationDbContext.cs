using DataLayer.Models;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DataAccess
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=BriefSysMySQL")
        {

        }

        /*Acceso Usuario*/
        public DbSet<Acceso_Usuario> Acceso_Usuarios { get; set; }

        /*RH*/
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Puesto> Puestos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Empleado_Detalle> EmpleadosDetalle { get; set; }

        /*Compras*/
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Orden_Detalle> Ordenes_Detalle { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }

        /*TI*/
        public DbSet<ServiceDesk> Tickets { get; set; }
        public DbSet<ServiceDesk_Detalle> Tickets_Detalle { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
