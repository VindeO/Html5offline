using System.Data.Entity;
using Html5OfflineMvc4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Html5OfflineMvc4.Controllers
{
   // [System.Web.Mvc.OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class TestController : Controller
    {
        //
        // GET: /Home/
        private Html5OfflineContext dbContext = new Html5OfflineContext();
        public ActionResult Index()
        {
         Html5OfflineContext context = new Html5OfflineContext();
            List<Person> persons = context.Persons.Select(person => person).ToList();
          //  ViewData["Model"] = dbContext.Versions.FirstOrDefault().VersionNumber;
            return View(persons);
        }

        public FileResult Download()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(Server.MapPath(Url.Content("~/Content/CI.pdf")));
            string fileName = "DI.pdf";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        public ActionResult Update()
        {
            Html5OfflineMvc4.Models.Version version = dbContext.Versions.FirstOrDefault();
            version.VersionNumber = (Int32.Parse(version.VersionNumber) + 1).ToString();
            dbContext.Entry(version).State = EntityState.Modified;

            Person person = new Person() { Name = "Person"+ version.VersionNumber, PhoneNumber = "XXX-XXX-XXXX"};
            dbContext.Persons.Add(person);
            dbContext.SaveChanges();

            return Content("Version updated to " + version.VersionNumber);

        }
    }
}
