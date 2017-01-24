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
                Id(b => b.id).GeneratedBy.Native();
                Map(b => b.name);
                Map(b => b.surname);
                Map(b => b.sex);
                Map(b => b.email);
                Map(b => b.password);
            }
    }
}
