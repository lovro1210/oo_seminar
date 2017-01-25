using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySeries.Model
{
    class UserSeries
    {
        private int _userID;
        private int _seriesID;
        public virtual int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        public virtual int SeriesID
        {
            get { return _seriesID; }
            set { _seriesID = value; }
        }
    }
}
