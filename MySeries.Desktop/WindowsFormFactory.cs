using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySeries.BaseLib;

namespace MySeries.Desktop
{
    public class WindowsFormFactory:IWindowsFormFactory
    {

        public IShowAllActorsView CreateShowAllActorsView()
        {
            var newFrm = new formViewAllActors();

            return newFrm; 
        }

        public IShowAllSeriesView CreateShowAllSeriesView()
        {
            var newFrm = new formViewAllSeries();

            return newFrm;
        }

        public IShowMySeriesView CreateShowMySeriesView()
        {
            var newFrm = new formViewMySeries();

            return newFrm;
        }


    }
}
