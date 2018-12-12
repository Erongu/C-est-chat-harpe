using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Salle;

namespace Controller.Strategy.Salle
{
    class StrategyMaitreRang : IStrategy
    {
        public void Call(object instance, object[] args) => ((Rang)args[0]).Tables.First(i => i.Groupe.Clients.Count() == 0 && i.Place >= ((Groupe)args[1]).Clients.Count()).Groupe = ((Groupe)args[1]);
    }
}
