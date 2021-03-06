﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using MySeries.Model;

namespace MySeries.DAL.Mappings
{
    public class SeriesMap : ClassMap<Series>
    {
        public SeriesMap() 
        {
            Id(b => b.Id).GeneratedBy.Native();
            Map(b => b.Name);
            Map(b => b.Genre);
            Map(b => b.Summary);
            HasManyToMany(b => b.Users)
                    .Cascade.All()
                    .Table("UserSeries");
            HasManyToMany(b => b.Actors)
                    .Cascade.All()
                    .Table("SeriesActor");
            HasMany(b => b.Episodes).Cascade.All();
        }

    }
}
