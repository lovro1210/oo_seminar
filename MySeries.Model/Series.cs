using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySeries.Model
{
    public class Series
    {
        private int _id;
        private String _name;
        private String _genre;
        private String _summary;
        private IList<User> _users;
        private IList<User> _actors;
        private IList<Episode> _episodes;

        public virtual int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public virtual String Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public virtual String Genre
        {
            get { return _genre; }
            set { _genre = value; }
        }
        public virtual String Summary
        {
            get { return _summary; }
            set { _summary = value; }
        }
        public virtual IList<User> Users
        {
            get { return _users; }
            set { _users = value; }
        }
        public virtual IList<User> Actors
        {
            get { return _actors; }
            set { _actors = value; }
        }
        public virtual IList<Episode> Episodes
        {
            get { return _episodes; }
            set { _episodes = value; }
        }
    }
}
