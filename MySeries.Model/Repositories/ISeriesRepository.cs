using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySeries.Model.Repositories
{
    interface ISeriesRepository
    {
        List<Series> getAllSeries();
        Series getSeries(int seriesId);

    }
}
