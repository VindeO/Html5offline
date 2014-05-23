using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Html5OfflineMvc4.Models
{
    public class Html5OfflineContext:DbContext
    {
        public Html5OfflineContext():base("Html5OfflineContext")
        {
            //var ensureDLLIsCopied =
            //   System.Data.Entity.SqlServer.SqlProviderServices.Instance; 
        }
        public DbSet<Version> Versions { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}