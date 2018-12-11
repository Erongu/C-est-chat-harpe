using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller.Strategy.Salle
{
    class StrategyMaitreHotel : IStrategy
    {
        public void Call(object instance, object[] args)
        {
            //(Client)instance.table = trouverTable(args[0], args[1], args[2], args[3]);
        }
    }
}
