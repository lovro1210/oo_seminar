using MySeries.DAL;
using MySeries.DAL.Repositories;
using MySeries.Model;
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
    }
}