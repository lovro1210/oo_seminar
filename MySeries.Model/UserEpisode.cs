using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySeries.Model
{
    public class UserEpisode
    {
        private User _user;
        private Episode _episode;
        private Boolean _watched;
        private String _comment;
        public virtual User User
        {
            get { return _user; }
            set { _user = value; }
        }
        public virtual Episode Episode
        {
            get { return _episode; }
            set { _episode = value; }
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
