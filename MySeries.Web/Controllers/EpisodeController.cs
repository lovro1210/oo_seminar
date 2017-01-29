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
    public class EpisodeController : Controller
    {
        // GET: Episodes
        [Authorize(Roles = "User")]
        public ActionResult MyEpisodes()
        {
            SeriesRepository seriesRepository = new SeriesRepository(NHibernateService.OpenSession());
            List<Series> listSubSeries = seriesRepository.getSubscribedSeries(Int32.Parse(User.Identity.Name));
            List<EpisodeViewModel> myEpisodes = new List<EpisodeViewModel>();
            foreach(var series in listSubSeries)
            {
                foreach(var episode in series.Episodes)
                {
                    EpisodeViewModel ep = new EpisodeViewModel();
                    ep.Id = episode.Id;
                    ep.Name = episode.Name;
                    ep.ReleaseDate = episode.ReleaseDate;
                    ep.Season = episode.Season;
                    ep.EpisodeNumber = episode.EpisodeNumber;
                    ep.Series = episode.Series.Name;
                    ep.Watched = episode.UserEpisode.Where(p => p.User.Id == 1).First().Watched;
                    myEpisodes.Add(ep);
                }

            }
            List<EpisodeViewModel> sortedEpisodes = myEpisodes.OrderByDescending(e => e.ReleaseDate).ToList();
            return View(sortedEpisodes);
        }

        public ActionResult About(int episodeId)
        {
            EpisodeRepository episodeRepository = new EpisodeRepository(NHibernateService.OpenSession());
            Episode episode = episodeRepository.getEpisode(episodeId);
            EpisodeViewModel epAbout = new EpisodeViewModel();
            epAbout.Id = episode.Id;
            epAbout.Name = episode.Name;
            epAbout.ReleaseDate = episode.ReleaseDate;
            epAbout.Season = episode.Season;
            epAbout.EpisodeNumber = episode.EpisodeNumber;
            epAbout.Series = episode.Series.Name;
            epAbout.Watched = episode.UserEpisode.Where(p => p.User.Id == 1).First().Watched;

            return View(epAbout);
        }
    }
}