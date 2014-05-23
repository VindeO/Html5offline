using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Html5OfflineMvc4.Models
{
    internal sealed class Html5OfflineDbInitializer : DropCreateDatabaseIfModelChanges<Html5OfflineContext>
    {
        protected override void Seed(Html5OfflineContext context)
        {
            context.Versions.Add(new Version() { VersionNumber = "1" });
            context.Persons.Add(new Person() { Name = "Person1", PhoneNumber = "XXX-XXX-XXXX" });
            context.SaveChanges();
        }
    }
}