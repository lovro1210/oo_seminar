﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySeries.Model.Repositories
{
    public interface IUserRepository
    {
        User getUser(User user);

        void addUser(User inUser);
    }
}
