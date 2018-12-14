using Model.Cuisine;
using System.Linq;

namespace Controller.Strategy.Cuisine
{
    public class StrategyPlonge : IStrategy
    {
        public void Call(object instance, object[] args)
        {
            MachineLaver machineLaver = new MachineLaver();

            switch (args[0])
            {
                case "vide":
                    machineLaver.VideMachineLaver();
                    break;
                case "add":
                    foreach (Ustensile ustensile in args.Skip(1))
                        machineLaver.AddUstensile(ustensile);
                    break;
            }
        }
    }
}