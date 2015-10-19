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
            return View();
        }

        public ActionResult Filtered()
        {
            ViewBag.type = "filtered";

            return View("Index");
        }

        public ActionResult User()
        {
            ViewBag.type = "user";

            return View("Index");
        }

        public ActionResult Sample()
        {
            ViewBag.type = "sample";

            return View("Index");
        }
    }
}