using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySeries.Web.Models
{
    public class SeriesAllViewModel
    {
        public int Id { get; set; }
        
        public String Name { get; set; }

        public bool Subscribed { get; set; }
        
    }
}