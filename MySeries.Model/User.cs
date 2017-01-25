using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySeries.Model
{
    public class User
    {
        private int _id;
        private String _name;
        private String _surname;
        private Boolean _sex;
        private String _email;
        private String _password;

        public virtual int Id 
        { 
            get { return _id; }
            set { _id = value; } 
        }
        public virtual String Name
        {
            get { return _name; } 
            set {_name = value; } 
        }
        public virtual String Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }
        public virtual Boolean Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }
        public virtual String Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public virtual String Password
        {
            get { return _password; }
            set { _password = value; }
        }
    }
}
