using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySeries.Model
{
    class Episode
    {
        private int _id;
        private String _name;
        private DateTime _releaseDate;
        private int _season;
        private int _episodeNumber;
        private Series _series;
        private String _summary;

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
        public virtual DateTime ReleaseDate
        {
            get { return _releaseDate; }
            set { _releaseDate = value; }
        }
        public virtual int Season
        {
            get { return _season; }
            set { _season = value; }
        }
        public virtual int EpisodeNumber
        {
            get { return _episodeNumber; }
            set { _episodeNumber = value; }
        }
        public virtual Series Series
        {
            get { return _series; }
            set { _series = value; }
        }
        public virtual String Summary
        {
            get { return _summary; }
            set { _summary = value; }
        }
    }
}
