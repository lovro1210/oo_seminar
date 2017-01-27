using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySeries.Web.Controllers
{
    public class EpisodeController : Controller
    {
        // GET: Episode
        public ActionResult MyEpisodes()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}