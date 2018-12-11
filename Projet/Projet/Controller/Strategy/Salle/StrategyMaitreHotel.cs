using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Salle;

namespace Controller.Strategy.Salle
{
    class StrategyMaitreHotel : IStrategy
    {
        public void Call(object instance, object[] args) => (Rang)args[0].Tables.First(i => i.GetGroupe().Clients.count() == 0).SetGroupe((Groupe)args[1]);
    }
}
