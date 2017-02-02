using MySeries.DAL;
using MySeries.DAL.Repositories;
using MySeries.Model;
using MySeries.Model.Repositories;
using MySeries.Web.Models;
using NHibernate;
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
            ISeriesRepository seriesRepository = new SeriesRepository(NHibernateService.OpenSession());
            List<Series> listSeries = seriesRepository.getAllSeries();
            List<SeriesAllViewModel> listViewModel = new List<SeriesAllViewModel>();
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
        [HttpGet]
        [Authorize(Roles = "User")]
        public ActionResult About(int seriesId)
        {
            ISeriesRepository seriesRepository = new SeriesRepository(NHibernateService.OpenSession());
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
            foreach (var episode in series.Episodes)
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
            var serActors = new List<SeriesActor>();
            foreach (var actor in series.Actors)
            {
                var serAct = new SeriesActor();
                serAct.Id = actor.Id;
                serAct.Name = actor.Name;
                serAct.Surname = actor.Surname;
                serActors.Add(serAct);
            }
            serAbout.Actors = serActors;

            return View(serAbout);
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public ActionResult About(SeriesAboutViewModel seriesAbout)
        {
            modifyUserSubscription(seriesAbout.Subscribed, Int32.Parse(User.Identity.Name), seriesAbout.Id);
            return RedirectToAction("About", new { seriesId = seriesAbout.Id });
        }

        private void modifyUserSubscription(bool subscribed, int userId, int seriesId)
        {
            ISession session = NHibernateService.OpenSession();
            SeriesRepository seriesRepository = new SeriesRepository(session);
            Series series = seriesRepository.getSeries(seriesId);
            UserRepository userRepository = new UserRepository(session);
            User user = userRepository.getUserById(userId);
            try
            {
                using (var transaction = session.BeginTransaction())
                {
                    if (subscribed)
                    {
                        series.Users.Add(user);
                        seriesRepository.updateSubscription(series);
                        transaction.Commit();
                    }
                    else
                    {
                        series.Users.Remove(user);
                        seriesRepository.updateSubscription(series);
                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        

        [HttpGet]
        public ActionResult AllSeries()
        {
            SeriesRepository seriesRepository = new SeriesRepository(NHibernateService.OpenSession());
            IList<Series> listSeries = seriesRepository.getAllSeries();

            foreach (Series s in listSeries)
            {
                // Remove circular dependencies
                s.Actors = null;
                s.Episodes = null;

                foreach (User u in s.Users)
                {
                    u.Series = null;
                    u.UserEpisode = null;
                }

            }
            return Json(listSeries, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult SeriesByActor(int actorId)
        {
            SeriesRepository seriesRepository = new SeriesRepository(NHibernateService.OpenSession());
            IList<Series> listSeries = seriesRepository.getSeriesByActor(actorId);

            foreach (Series s in listSeries)
            {
                // Remove circular dependencies
                s.Actors = null;
                s.Episodes = null;

                foreach (User u in s.Users)
                {
                    u.Series = null;
                    u.UserEpisode = null;
                }
            }

            return Json(listSeries, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void ModifySubscription(bool subscribed, int userId, int seriesId)
        {
            modifyUserSubscription(subscribed, userId, seriesId);
        }
    }
}

