﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySeries.Model.Repositories
{
    public interface IActorRepository
    {
        List<Actor> getActors();
    }
}
