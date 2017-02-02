using MySeries.BaseLib;
using MySeries.DAL;
using MySeries.DAL.Repositories;
using MySeries.Model;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySeries.Controllers
{
    public class EpisodeController
    {
        public void ViewUserEpisodes(IShowMySeriesView inForm, IMainFormController mainController)
        {
            EpisodeRepository episodeRepository = new EpisodeRepository(NHibernateService.OpenSession());
            SeriesRepository seriesRepository = new SeriesRepository(NHibernateService.OpenSession());
            // dohvati sve accounte i proslijedi ih View-u
            List<Series> listSeries = seriesRepository.getSubscribedSeries(Common.user.Id);
            List<Episode> listEpisode = new List<Episode>();
            List<bool> watched = new List<bool>();
            foreach (var series in listSeries)
            {
                foreach (var episode in series.Episodes)
                {
                    Episode ep = new Episode();
                    ep.Id = episode.Id;
                    ep.Name = episode.Name;
                    ep.ReleaseDate = episode.ReleaseDate;
                    ep.Season = episode.Season;
                    ep.EpisodeNumber = episode.EpisodeNumber;
                    ep.Series = episode.Series;
                    if (episode.UserEpisode.Where(p => p.User.Id == Common.user.Id).Any())
                    {
                        watched.Add(episode.UserEpisode.Where(p => p.User.Id == Common.user.Id).First().Watched);
                    }
                    else
                    {
                        watched.Add(false);
                    }
                    listEpisode.Add(ep);
                }

            }
            List<Episode> sortedEpisodes = listEpisode.OrderByDescending(e => e.ReleaseDate).ToList();
            

            // zašto proslijeđujemo i mainController?
            // zato što na ovom View-u imamo "Add new account" i "Edit new account" funkcionalnost!
            inForm.ShowMyEpisodes(listEpisode, watched);
        }
        public Episode GetEpisodeById(int id)
        {
            EpisodeRepository episodeRepository = new EpisodeRepository(NHibernateService.OpenSession());
            Episode episode = episodeRepository.getEpisode(id);
            return episode;
        }
        public UserEpisode GetUserEpisode(User user, Episode episode)
        {
            ISession session = NHibernateService.OpenSession();
            EpisodeRepository episodeRepositroy = new EpisodeRepository(session);
            UserEpisode dataUserEpisode = episodeRepositroy.getUserEpisode(episode, user);
            /*if (dataUserEpisode == null)
            {
                dataUserEpisode = new UserEpisode();
                dataUserEpisode.Episode = episode;
                dataUserEpisode.User = user;
                var transaction = session.BeginTransaction();
                episodeRepositroy.addOrUpdateUserEpisode(dataUserEpisode);
                transaction.Commit();
            }*/
            return dataUserEpisode;
        }
        public void UpdateUserEpisode(UserEpisode userEpisode)
        {
            ISession session = NHibernateService.OpenSession();
            EpisodeRepository episodeRepositroy = new EpisodeRepository(session);
            // Dohvati userepisode po userid i episodeid
            // promijeni vrijednost na userepisode.watched
            // spremi
            UserEpisode dataUserEpisode = episodeRepositroy.getUserEpisode(userEpisode.Episode, userEpisode.User);
            //DODAJ USER EPISOD AKO NULL

            dataUserEpisode.Watched = userEpisode.Watched;
            userEpisode.Episode.UserEpisode.Add(userEpisode);
            userEpisode.User.UserEpisode.Add(userEpisode);
            var transaction = session.BeginTransaction();
            episodeRepositroy.addOrUpdateUserEpisode(userEpisode);
            transaction.Commit();
        }
        public void EpisodeWatched(int id, bool watched)
        {
            //Episode ep = episodeRepository.getEpisode(episode.Id);
            ISession session = NHibernateService.OpenSession();
            UserRepository userRepository = new UserRepository(session);
            EpisodeRepository episodeRepository = new EpisodeRepository(session);
            Episode episode = episodeRepository.getEpisode(id);
            try
            {
                using (var transaction = session.BeginTransaction())
                {
                    if (watched)
                    {

                        UserEpisode userEpisode = episodeRepository.getUserEpisode(episode, Common.user);
                        if (userEpisode == null)
                        {
                            userEpisode = new UserEpisode();
                            userEpisode.Episode = episode;
                            userEpisode.User = Common.user;
                        }
                        userEpisode.Watched = true; 
                        episode.UserEpisode.Add(userEpisode);
                        Common.user.UserEpisode.Add(userEpisode);
                        episodeRepository.addOrUpdateUserEpisode(userEpisode);
                        transaction.Commit();
                    }
                    else
                    {
                        var userEpisode = new UserEpisode();
                        userEpisode.Episode = episode;
                        userEpisode.User = Common.user;
                        episodeRepository.deleteUserEpisode(userEpisode);
                        transaction.Commit();
                    }
                }
            }


            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
