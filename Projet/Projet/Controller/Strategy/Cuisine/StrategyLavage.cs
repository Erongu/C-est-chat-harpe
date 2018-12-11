using Model.Cuisine;

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
                    machineLaver.AddUstensile(new Ustensile((Ustensile.TYPE)args[1]));
                    break;
            }
        }
    }
}