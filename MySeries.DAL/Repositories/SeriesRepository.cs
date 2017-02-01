using MySeries.DAL.Repositories;
using MySeries.Model;
using MySeries.Model.Repositories;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySeries.DAL.Repositories
{
    public class SeriesRepository : ISeriesRepository
    {
        private ISession _currSession = null;
        public SeriesRepository(ISession inSession)
        {
            _currSession = inSession;
        }

        public List<Series> getAllSeries()
        {
            List<Series> listSeries = _currSession.Query<Series>().ToList();

            return listSeries;
        }

        public Series getSeries(int seriesId)
        {
            Series series = _currSession.Get<Series>(seriesId);

            return series;

        }

        public List<Series> getSubscribedSeries(int userId)
        {
            List<Series> series = _currSession.Query<Series>().Where(p => p.Users.Any(x => x.Id == userId)).ToList();
            return series;
        }

        public void updateSubscription(Series series)
        {
                _currSession.SaveOrUpdate(series);
        }

        public void removeSubscription(Series series)
        {
                _currSession.SaveOrUpdate(series);
        }

    }
}
