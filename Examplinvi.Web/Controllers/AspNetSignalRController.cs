using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Examplinvi.Web.Controllers
{
    public class AspNetSignalRController : Controller
    {
        // GET: AspNetSignalR
        public ActionResult Index()
        {
            return RedirectToAction("FilteredStream");
        }

        public ActionResult FilteredStream()
        {
            ViewBag.type = "filtered";

            return View("Index");
        }

        public new ActionResult UserStream()
        {
            ViewBag.type = "user";

            return View("Index");
        }

        public ActionResult SampleStream()
        {
            ViewBag.type = "sample";

            return View("Index");
        }
    }
}