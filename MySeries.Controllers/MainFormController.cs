using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySeries.BaseLib;

namespace MySeries.Controllers
{
    public class MainFormController:IMainFormController
    {
        private readonly IWindowsFormFactory _formsFactory = null;
        public MainFormController(IWindowsFormFactory inFormFactory)
        {
            _formsFactory = inFormFactory;
        }

        public void ShowAllActors()
        {
            var actorController = new ActorController();

            var newFrm = _formsFactory.CreateShowAllActorsView();

            actorController.ViewAllActors(newFrm, this);
        }

        public void ShowAllSeries()
        {
            var seriesController = new SeriesController();

            var newFrm = _formsFactory.CreateShowAllSeriesView();

            seriesController.ViewAllSeries(newFrm, this);
        }

        public void ShowMyEpisodes()
        {
            var episodeController = new EpisodeController();

            var newFrm = _formsFactory.CreateShowMySeriesView();

            episodeController.ViewUserEpisodes(newFrm, this);
        }
    }
}
