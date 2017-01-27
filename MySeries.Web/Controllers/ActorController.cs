using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySeries.Web.Controllers
{
    public class ActorController : Controller
    {
        // GET: Actor
        public ActionResult Actors()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}