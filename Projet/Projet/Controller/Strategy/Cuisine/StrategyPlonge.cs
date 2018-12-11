using Model.Cuisine;

namespace Controller.Strategy.Cuisine
{
    public class StrategyPlonge : IStrategy
    {
        public void Call(object instance, object[] args)
        {
            LaveVaisselle laveVaisselle = new LaveVaisselle();
   
            switch (args[0]) {
                case "vide":
                    laveVaisselle.VideLaveVaisselle();                 
                    break;
                case "add":
                    laveVaisselle.AddUstensile(new Ustensile((Ustensile.TYPE)args[1]));
                    break;
            }
        }
    }
}