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
    public class SeriesController : Controller
    {
        // GET: Series
        public ActionResult All()
        {
            return View();
        }

        public ActionResult About(int seriesId)
        {
            SeriesRepository seriesRepository = new SeriesRepository(NHibernateService.OpenSession());
            Series series = seriesRepository.getSeries(seriesId);


            return View();
        }
    }
}