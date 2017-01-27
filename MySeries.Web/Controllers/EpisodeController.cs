using MySeries.DAL;
using MySeries.DAL.Repositories;
using MySeries.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySeries.Web.Controllers
{
    public class EpisodeController : Controller
    {
        // GET: Episodes
        public ActionResult MyEpisodes()
        {
            SeriesRepository seriesRepository = new SeriesRepository(NHibernateService.OpenSession());
            List<Series> listSeries = seriesRepository.getAllSeries();
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}