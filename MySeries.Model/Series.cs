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
    }
}
