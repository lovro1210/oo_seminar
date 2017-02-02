using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySeries.Model;

namespace MySeries.BaseLib
{
    public interface IShowAllSeriesView
    {
        void ShowAllSeries(List<Series> listSubSeries, List<Series> listNoSubSeries);
    }
}
