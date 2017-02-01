using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySeries.Model;
using MySeries.DAL.Repositories;
using MySeries.Model.Repositories;
using NHibernate.Linq;

namespace MySeries.DAL.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private ISession _currSession = null;
        public ActorRepository(ISession inSession)
        {
            _currSession = inSession;
        }

        public List<Actor> getActors()
        {
            List<Actor> listActor = _currSession.Query<Actor>().ToList();

            return listActor;
        }

        public Actor getActor(int actorId)
        {
            Actor actor = _currSession.Get<Actor>(actorId);

            return actor;
        }
    }
}
