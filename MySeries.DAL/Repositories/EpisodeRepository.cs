using MySeries.Model;
using MySeries.Model.Repositories;
using NHibernate;
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
    }
}
