using MySeries.Model;
using MySeries.Model.Repositories;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySeries.DAL.Repositories
{
    public class EpisodeRepository : IEpisodeRepository
    {
        private ISession _currSession = null;
        public EpisodeRepository(ISession inSession)
        {
            _currSession = inSession;
        }
        public List<Episode> getAllEpisodes()
        {
            return new List<Episode>();
        }
        public Episode getEpisode(int episodeId)
        {
            Episode episode = _currSession.Get<Episode>(episodeId);

            return episode;
        }

        public void addOrUpdateUserEpisode(UserEpisode userepisode)
        {
            _currSession.SaveOrUpdate(userepisode);
        }

        public void deleteUserEpisode(UserEpisode userEpisode)
        {
            _currSession.Delete(userEpisode);
        }

        public UserEpisode getUserEpisode(Episode ep, User us)
        {
            UserEpisode userEpisode = _currSession.Get<UserEpisode>(new UserEpisode() { Episode= ep, User = us });
            
            return userEpisode;
        }

        public IList<Episode> EpisodeBySeriesId(int seriesId)
        {
            IList<Episode> listEpisodes = _currSession.CreateCriteria<Episode>()
                                    .Add(Expression.Eq("Series.Id", seriesId))
                                    .List<Episode>();
            return listEpisodes;
        }

    }
}
