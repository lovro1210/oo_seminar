using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySeries.Web.Models
{
    public class ActorAboutViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public List<ActorSeries> Series { get; set; }
    }

    public class ActorSeries
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}