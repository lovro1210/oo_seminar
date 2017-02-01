using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MySeries.Web.Models
{
    public class SeriesAboutViewModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Genre { get; set; }
        public String Summary { get; set; }
        public List<SeriesEpisode> Episodes { get; set; }
        public List<SeriesActor> Actors { get; set; }
        public bool Subscribed { get; set; }

      /*  public SeriesAboutViewModel(int id, String name, String Genre, String Summary)
        {

        } */
        
    }

    public class SeriesActor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    public class SeriesEpisode
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public int Season { get; set; }
        public int EpisodeNumber { get; set; }
        public bool Watched { get; set; }
    }
}