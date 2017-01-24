using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySeries.Model
{
    public class User
    {
        public virtual int id { get; set; }
        public virtual String name { get; set; }
        public virtual String surname { get; set; }
        public virtual Boolean sex { get; set; }
        public virtual String email { get; set; }
        public virtual String password { get; set; }
    }
}
