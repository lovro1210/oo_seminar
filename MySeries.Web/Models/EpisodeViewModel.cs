using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySeries.Web.Models
{
    public class EpisodeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Season { get; set; }
        public int EpisodeNumber { get; set; }
        public String Series { get; set; }
        public String Summary { get; set; }
        public bool Watched { get; set; }
    }
}