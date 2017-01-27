using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySeries.Model
{
    public class UserEpisode
    {
        private int _userID;
        private int _episodeID;
        private Boolean _watched;
        private String _comment;
        public virtual int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        public virtual int EpisodeID
        {
            get { return _episodeID; }
            set { _episodeID = value; }
        }
        public virtual Boolean Watched
        {
            get { return _watched; }
            set { _watched = value; }
        }
        public virtual String Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

    }
}
