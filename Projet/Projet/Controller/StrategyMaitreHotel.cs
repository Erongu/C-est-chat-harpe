using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    class StrategyMaitreHotel : IStrategy
    {
        private int trouverTable(int numeroRang, int numeroCarre, int nombrePersonne, Restaurant restaurant)
        {
            foreach (Table table in new Rang(numeroRang, numeroCarre).GetTable())
            {
                if (table.Groupe == null)
                {
                    return table.Numero;
                }
            }
            return 0;
        }

        public void method(object instance, object[] args)
        {
            //(Client)instance.table = trouverTable(args[0], args[1], args[2], args[3]);
        }
    }
}
