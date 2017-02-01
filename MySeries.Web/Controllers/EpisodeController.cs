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
            foreach (var series in listSubSeries)
            {
                foreach (var episode in series.Episodes)
                {
                    EpisodeViewModel ep = new EpisodeViewModel();
                    ep.Id = episode.Id;
                    ep.Name = episode.Name;
                    ep.ReleaseDate = episode.ReleaseDate;
                    ep.Season = episode.Season;
                    ep.EpisodeNumber = episode.EpisodeNumber;
                    ep.Series = episode.Series.Name;
                    if (episode.UserEpisode.Where(p => p.User.Id == Int32.Parse(User.Identity.Name)).Any())
                    {
                        ep.Watched = episode.UserEpisode.Where(p => p.User.Id == Int32.Parse(User.Identity.Name)).First().Watched;
                    } else
                    {
                        ep.Watched = false;
                    }
                    myEpisodes.Add(ep);
                }

            }
            List<EpisodeViewModel> sortedEpisodes = myEpisodes.OrderByDescending(e => e.ReleaseDate).ToList();
            return View(sortedEpisodes);
        }
        [HttpGet]
        [Authorize(Roles = "User")]
        public ActionResult About(int episodeId)
        {
            EpisodeRepository episodeRepository = new EpisodeRepository(NHibernateService.OpenSession());
            Episode episode = episodeRepository.getEpisode(episodeId);
            EpisodeAboutViewModel epAbout = new EpisodeAboutViewModel();
            epAbout.Id = episode.Id;
            epAbout.Name = episode.Name;
            epAbout.ReleaseDate = episode.ReleaseDate;
            epAbout.Season = episode.Season;
            epAbout.EpisodeNumber = episode.EpisodeNumber;
            epAbout.Summary = episode.Summary;
            epAbout.Series = episode.Series.Name;
            if (episode.UserEpisode.Where(p => p.User.Id == Int32.Parse(User.Identity.Name)).Any())
            {
                epAbout.Comment = episode.UserEpisode.Where(p => p.User.Id == Int32.Parse(User.Identity.Name)).First().Comment;
                epAbout.Watched = episode.UserEpisode.Where(p => p.User.Id == Int32.Parse(User.Identity.Name)).First().Watched;
            } else
            {
                epAbout.Comment = "";
                epAbout.Watched = false;
            }
            return View(epAbout);
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public ActionResult About(EpisodeAboutViewModel episode)
        {
            ISession session = NHibernateService.OpenSession();
            EpisodeRepository episodeRepository = new EpisodeRepository(session);
            Episode ep = episodeRepository.getEpisode(episode.Id);
            UserRepository userRepository = new UserRepository(session);
            User user = userRepository.getUserById(Int32.Parse(User.Identity.Name));
            
            try
            {
                using (var transaction = session.BeginTransaction())
                {
                    if (episode.Watched)
                    {

                        UserEpisode userEpisode = episodeRepository.getUserEpisode(ep, user);
                        if (userEpisode == null)
                        {
                            userEpisode = new UserEpisode();
                            userEpisode.Episode = ep;
                            userEpisode.User = user;
                        }
                        userEpisode.Comment = episode.Comment;
                        userEpisode.Watched = episode.Watched;
                        ep.UserEpisode.Add(userEpisode);
                        user.UserEpisode.Add(userEpisode);
                        episodeRepository.addOrUpdateUserEpisode(userEpisode);
                        transaction.Commit();
                    } else
                    {
                        var userEpisode = new UserEpisode();
                        userEpisode.Episode = ep;
                        userEpisode.User = user;
                        episodeRepository.deleteUserEpisode(userEpisode);
                        transaction.Commit();
                    }
                }
            }


            catch (Exception ex)
            {
                throw;
            }
            return RedirectToAction("About", new { episodeId = episode.Id });
        }

        [HttpGet]
        public ActionResult UserSeries(int userId)
        {
            // TODO This could be optimized by querying into database for user episodes
            IEpisodeRepository repo = new EpisodeRepository(NHibernateService.OpenSession());
            var episodeList = repo.getAllEpisodes();

            IList<Episode> userEpisode = new List<Episode>();
            foreach (Episode e in episodeList)
            {
                IList<UserEpisode> ueList = e.UserEpisode;
                foreach (UserEpisode ue in ueList)
                {
                    if (ue.User?.Id == userId)
                    {
                        // Remove circular dependencies
                        ue.Episode = null;
                        ue.User.Series = null;
                        ue.User.UserEpisode = null;
                        userEpisode.Add(e);
                    }
                }
            }

            foreach (Episode e in userEpisode)
            {
                if (e.Series == null) break;
                // Remove circular dependencies
                e.Series.Actors = null;
                e.Series.Episodes = null;
                e.Series.Users = null;
            }

            return Json(userEpisode, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult EpisodeDetails(int episodeId)
        {
            IEpisodeRepository repo = new EpisodeRepository(NHibernateService.OpenSession());
            var episode = repo.getEpisode(episodeId);

            if (episode.Series != null)
            {
                // Remove circular dependencies
                Series s = episode.Series;
                s.Actors = null;
                s.Episodes = null;
                s.Users = null;
            }

            if (episode.UserEpisode != null)
            {
                UserEpisode ue = episode.UserEpisode.FirstOrDefault();
                ue.User = null;
                ue.Episode = null;
            }

            return Json(episode, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult EpisodeBySeriesId(int seriesId)
        {
            // TODO This could be optimized by querying into database for user episodes
            IEpisodeRepository repo = new EpisodeRepository(NHibernateService.OpenSession());
            var episodeList = repo.EpisodeBySeriesId(seriesId);

            foreach (Episode e in episodeList)
            {
                if (e.UserEpisode != null)
                {
                    foreach (UserEpisode ue in e.UserEpisode)
                    {
                        ue.Episode = null;

                        if (ue.User != null)
                        {
                            ue.User.Series = null;
                            ue.User.UserEpisode = null;
                        }
                    }
                }

                if (e.Series != null)
                {
                    e.Series.Actors = null;
                    e.Series.Episodes = null;
                    e.Series.Users = null;
                }
            }

            return Json(episodeList, JsonRequestBehavior.AllowGet);
        }
    }
}