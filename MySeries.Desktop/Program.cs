using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySeries.DAL;
using MySeries.Model.Repositories;
using MySeries.Controllers;


namespace MySeries.Desktop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // kreirati konfiguraciju i SessionFactory za NHIbernate
            //NHibernateService.OpenSessionFactory();
            //NHibernateService.CreateUserAndSaveToDatabase();
            //NHibernateService.ViewAllUsers();
            //WindowsFormFactory _formsFactory = new WindowsFormFactory();

            //UserController userController = new UserController(_formsFactory);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new formLogin());
        }
    }
}
