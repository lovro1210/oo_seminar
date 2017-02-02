using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySeries.BaseLib;
using MySeries.DAL.Repositories;
using MySeries.DAL;
using MySeries.Model;
using NHibernate;

namespace MySeries.Controllers
{
    public class SeriesController
    {
        internal void ViewAllSeries(IShowAllSeriesView newFrm, MainFormController mainFormController)
        {
            //EpisodeRepository episodeRepository = new EpisodeRepository(NHibernateService.OpenSession());
            SeriesRepository seriesRepository = new SeriesRepository(NHibernateService.OpenSession());
            // dohvati sve accounte i proslijedi ih View-u
            List<Series> listSubSeries = seriesRepository.getSubscribedSeries(Common.user.Id);
            List<Series> listNoSubSeries = seriesRepository.getAllSeries().Except(listSubSeries).ToList();


            // zašto proslijeđujemo i mainController?
            // zato što na ovom View-u imamo "Add new account" i "Edit new account" funkcionalnost!
            newFrm.ShowAllSeries(listSubSeries, listNoSubSeries);
        }

        public Series GetSeriesById(int id)
        {
            SeriesRepository seriesRepository = new SeriesRepository(NHibernateService.OpenSession());
            Series series = seriesRepository.getSeries(id);
            return series;
        }

        public void UpdateSeriesSub(int id, bool isChecked)
        {
            ISession session = NHibernateService.OpenSession();
            SeriesRepository seriesRepository = new SeriesRepository(session);
            Series series = seriesRepository.getSeries(id);
            UserRepository userRepositroy = new UserRepository(session);
            User user = userRepositroy.getUser(Common.user);
            try
            {
                using (var transaction = session.BeginTransaction())
                {
                    if (isChecked)
                    {
                        series.Users.Add(user);
                        seriesRepository.updateSubscription(series);
                        transaction.Commit();
                    }
                    else
                    {
                        series.Users.Remove(user);
                        seriesRepository.updateSubscription(series);
                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void AddOrRemoveSeriesSub(int id, bool isChecked)
        {
            SeriesRepository seriesRepository = new SeriesRepository(NHibernateService.OpenSession());
            Series series = seriesRepository.getSeries(id);
            if (isChecked == true && (series.Users.Contains(Common.user)))
            {
                series.Users.Add(Common.user);
            }
            if (isChecked == false && series.Users.Contains(Common.user))
            {
                series.Users.Remove(Common.user);
            }
            seriesRepository.updateSubscription(series);
        }
    }
}
