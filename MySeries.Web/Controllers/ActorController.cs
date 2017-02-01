using MySeries.DAL;
using MySeries.DAL.Repositories;
using MySeries.Model;
using MySeries.Model.Repositories;
using MySeries.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySeries.Web.Controllers
{
    public class ActorController : Controller
    {
        // GET: Actor
        public ActionResult Actors()
        {
            ActorRepository actorRepository = new ActorRepository(NHibernateService.OpenSession());
            List<Actor> listActor = actorRepository.getActors();
            List<ActorViewModel> listViewModel = new List<ActorViewModel>();
            foreach(var actor in listActor)
            {
                ActorViewModel avm = new ActorViewModel();
                avm.Id = actor.Id;
                avm.Name = actor.Name;
                avm.Surname = actor.Surname;
                listViewModel.Add(avm);
            }

            return View(listViewModel);
        }

        public ActionResult About(int actorId)
        {
            ActorRepository actorRepository = new ActorRepository(NHibernateService.OpenSession());
            Actor actor = actorRepository.getActor(actorId);
            ActorAboutViewModel actorAbout = new ActorAboutViewModel();
            actorAbout.Id = actor.Id;
            actorAbout.Name = actor.Name;
            actorAbout.Surname = actor.Surname;
            actorAbout.Birthday = actor.Birthday;
            var actorSeries = new List<ActorSeries>();
            foreach(var series in actor.Series)
            {
                var actSer = new ActorSeries();
                actSer.Id = series.Id;
                actSer.Name = series.Name;
                actorSeries.Add(actSer);
            }
            actorAbout.Series = actorSeries;
   
            return View(actorAbout);
        }

        [HttpGet]
        public ActionResult GetActors()
        {
            IActorRepository repo = new ActorRepository(NHibernateService.OpenSession());
            var actorList = repo.getActors();

            foreach (Actor a in actorList)
            {
                a.Series = null;
            }

            return Json(actorList, JsonRequestBehavior.AllowGet);
        }
    }
}