using FluentNHibernate.Mapping;
using MySeries.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySeries.DAL.Mappings
{
    public class UserMap : ClassMap<User>
    {
            public UserMap()
            {
                Id(b => b.Id).GeneratedBy.Native();
                Map(b => b.Name);
                Map(b => b.Surname);
                Map(b => b.Sex);
                Map(b => b.Email);
                Map(b => b.Password);
                HasManyToMany(b => b.Series)
                    .Cascade.All()
                    .Table("UserSeries")
                    .Inverse();
                HasMany(b => b.UserEpisode).Cascade.All();
            }
    }
}
