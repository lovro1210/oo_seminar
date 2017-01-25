using MySeries.Model;
using MySeries.Model.Repositories;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySeries.DAL.Repositories
{
    class UserRepository : IUserRepository
    {
        private ISession _currSession = null;
        public UserRepository(ISession inSession)
        {
            _currSession = inSession;
        }

        public List<User> getUsers()
        {
            List<User> listUsers = _currSession.Query<User>().ToList();

            return listUsers;
        }

        public void addUser(User inUser)
        {
            _currSession.Save(inUser);
        }
    }
}
