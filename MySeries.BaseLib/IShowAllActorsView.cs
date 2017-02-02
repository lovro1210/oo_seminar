using MySeries.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySeries.BaseLib
{
    public interface IShowAllActorsView
    {
        void ShowAllActors(List<Actor> listActor);
    }
}
