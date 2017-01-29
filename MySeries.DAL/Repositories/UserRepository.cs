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
    public class UserRepository : IUserRepository
    {
        private ISession _currSession = null;
        public UserRepository(ISession inSession)
        {
            _currSession = inSession;
        }

        public User getUser(User user)
        {
            User u = _currSession.Query<User>().Where(x => x.Email.ToLower() == user.Email.ToLower() &&
       x.Password == user.Password).FirstOrDefault();

            return u;
        }

        public void addUser(User inUser)
        {
            _currSession.Save(inUser);
        }
    }
}
