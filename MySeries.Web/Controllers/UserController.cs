using MySeries.DAL;
using MySeries.DAL.Repositories;
using MySeries.Model;
using MySeries.Model.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySeries.Web.Controllers
{
    public class UserController : Controller
    {
        [HttpPost]
        public ActionResult LoginUser(string email, string password)
        {
            IUserRepository repo = new UserRepository(NHibernateService.OpenSession());
            User user = new User();
            user.Email = email;
            user.Password = password;
            var u = repo.getUser(user);
            if (u != null)
            {
                u.Series = null;
                u.UserEpisode = null;
            }

            return Json(u, JsonRequestBehavior.AllowGet);
        }

    }
}