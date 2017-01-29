using MySeries.DAL;
using MySeries.DAL.Repositories;
using MySeries.Model;
using MySeries.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

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
            var y = User.Identity.Name;
            foreach (var series in listSeries)
            {
                SeriesAllViewModel newSeries = new SeriesAllViewModel();
                newSeries.Id = series.Id;
                newSeries.Name = series.Name;
                
                if (User.Identity.Name != "")
                {
                    newSeries.Subscribed = series.Users.Any(x => x.Id == Int32.Parse(User.Identity.Name));
                }
                listViewModel.Add(newSeries);
            }
            return View(listViewModel);
        }

        public ActionResult About(int seriesId)
        {
            SeriesRepository seriesRepository = new SeriesRepository(NHibernateService.OpenSession());
            Series series = seriesRepository.getSeries(seriesId);
            SeriesAboutViewModel serAbout = new SeriesAboutViewModel();
            serAbout.Id = series.Id;
            serAbout.Name = series.Name;
            serAbout.Summary = series.Summary;
            if (User.Identity.Name != "")
            {
                serAbout.Subscribed = series.Users.Any(x => x.Id == Int32.Parse(User.Identity.Name));
            }
            var serEps = new List<SeriesEpisode>();
            foreach(var episode in series.Episodes)
            {
                var serEp = new SeriesEpisode();
                serEp.Id = episode.Id;
                serEp.ReleaseDate = episode.ReleaseDate;
                serEp.Season = episode.Season;
                serEp.EpisodeNumber = episode.EpisodeNumber;
                serEp.Watched = episode.UserEpisode.Any(x => x.Watched == true);
                serEps.Add(serEp);
            }
            serAbout.Episodes = serEps;

            return View(serAbout);
        }
    }
}