using Html5OfflineMvc4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

namespace Html5OfflineMvc4.Controllers
{
    public class OfflineController : Controller
    {
        //
        // GET: /Offline/
        Html5OfflineContext dbContext = new Html5OfflineContext();
        public ActionResult Index()
        {
            return new OfflineResult(new[]
        {
            //Url.Content("~/Content/CI.pdf")
            Url.Action("Index", "Test")
        },
       fingerprint: dbContext.Versions.FirstOrDefault().VersionNumber);
        }

    }
}
