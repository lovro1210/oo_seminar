using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using MySeries.Model;

namespace MySeries.DAL.Mappings
{
    public class EpisodeMap : ClassMap<Episode>
    {
        public EpisodeMap()
        {
            Id(b => b.Id).GeneratedBy.Native();
            Map(b => b.Name);
            Map(b => b.ReleaseDate);
            Map(b => b.Season);
            Map(b => b.EpisodeNumber);
            References(b => b.Series);
            Map(b => b.Summary);
            HasMany(b => b.UserEpisode)
                .Cascade.All();
        }
          

    }
}
