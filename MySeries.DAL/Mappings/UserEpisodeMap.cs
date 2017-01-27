using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using MySeries.Model;

namespace MySeries.DAL.Mappings
{
    public class UserEpisodeMap : ClassMap<UserEpisode>
    {
        public UserEpisodeMap()
        {
            CompositeId()
                .KeyReference(b => b.User)
                .KeyReference(b => b.Episode);
            Map(b => b.Watched);
            Map(b => b.Comment);
        }

    }
}
