using Model;
using System.Linq;

namespace Controller.Strategy.Cuisine
{
    public class StrategyCuisinier : IStrategy
    {
        public void Call(object instance, object[] args)
        {
            foreach (int plat in args)
            {
                if (DatabaseController.Instance.CheckStock(plat).All(i => i>0))
                {
                    DatabaseController.Instance.UpdateStock(plat);
                }
            }
        }
    }
}