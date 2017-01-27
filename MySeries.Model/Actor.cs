using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySeries.Model
{
    public class Actor
    {
        private int _id;
        private String _name;
        private String _surname;
        private DateTime _birthday;
        private IList<Series> _series;

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
        public virtual String Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }
        public virtual DateTime Birthday 
        { 
            get { return _birthday;}
            set { _birthday = value; } 
        }
        public virtual IList<Series> Series
        {
            get { return _series; }
            set { _series = value; }
        }
    }
}
