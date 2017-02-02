using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySeries.DAL.Repositories;
using MySeries.DAL;
using MySeries.Model;
using MySeries.BaseLib;

namespace MySeries.Controllers
{
    public class UserController
    {
        public bool UserValidate(string email, string password)
        {
            UserRepository userRepository = new UserRepository(NHibernateService.OpenSession());
            User user = new User();
            user.Email = email;
            user.Password = password;
            User dataUser = userRepository.getUser(user);
            if (dataUser == null)
            {
                return false;
            }
            //TODO COmmon to USER
            if (dataUser.Email== email) { 
                Common.user = dataUser;
                return true;
                }
            
            return false;
        }
    }
}
