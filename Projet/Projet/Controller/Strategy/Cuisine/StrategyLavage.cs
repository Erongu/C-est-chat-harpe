using Model.Cuisine;

namespace Controller.Strategy.Cuisine
{
    public class StrategyLavage : IStrategy
    {
        public void Call(object instance, object[] args)
        {
            LaveVaisselle laveVaisselle = new LaveVaisselle();
   
            switch (args[0]) {
                case "vide":
                    laveVaisselle.VideLaveVaisselle();                 
                    break;
                case "add":
                    foreach (Ustensile ustensile in args.Skip(1)) 
                    {
                        laveVaisselle.AddUstensile(ustensile);
                    }
                    break;
            }
        }
    }
}