using MySeries.Model;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySeries.DAL.Repositories
{
    public class SeriesRepository
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
    }
}
