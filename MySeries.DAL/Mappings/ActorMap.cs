using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using MySeries.Model;

namespace MySeries.DAL.Mappings
{
    public class ActorMap : ClassMap<Actor>
    {
        public ActorMap()
        {
            Id(b => b.Id).GeneratedBy.Native();
            Map(b => b.Name);
            Map(b => b.Surname);
            Map(b => b.Birthday);
            HasManyToMany(b => b.Series)
                    .Cascade.All()
                    .Table("SeriesActor");
        }

    }
}
