using MySeries.DAL;
using MySeries.DAL.Repositories;
using MySeries.Model;
using MySeries.Web.Models;
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
            SeriesRepository seriesRepository = new SeriesRepository(NHibernateService.OpenSession());
            List<Series> listSeries = seriesRepository.getAllSeries();
            List<SeriesAllViewModel> listViewModel = new List<SeriesAllViewModel>();
            foreach (var series in listSeries)
            {
                SeriesAllViewModel newSeries = new SeriesAllViewModel();
                newSeries.Id = series.Id;
                newSeries.Name = series.Name;
                newSeries.Subscribed = series.Users.Any(x => x.Id == 1);
                listViewModel.Add(newSeries);
            }
            return View(listViewModel);
        }

        public ActionResult About(int seriesId)
        {
            SeriesRepository seriesRepository = new SeriesRepository(NHibernateService.OpenSession());
            Series series = seriesRepository.getSeries(seriesId);


    //        SeriesAboutViewModel serAbout = new SeriesAboutViewModel(series.Id, );




            return View();
        }
    }
}