﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MySeries.Web.Models
{
    public class EpisodeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public int Season { get; set; }
        public int EpisodeNumber { get; set; }
        public String Series { get; set; }
        public bool Watched { get; set; }
    }
}