using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySeries.Model.Repositories
{
    public interface ISeriesRepository
    {
        List<Series> getAllSeries();
        Series getSeries(int seriesId);
        List<Series> getSubscribedSeries(int userId);               
        IList<Series> getSeriesByActor(int actorId);

    }
}
