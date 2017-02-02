using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySeries.Model;
namespace MySeries.BaseLib
{
    public interface IShowMySeriesView
    {
        void ShowMyEpisodes(List<Episode> listEpisode, List<bool> watched);
    }
}
