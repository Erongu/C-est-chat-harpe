using Model;

namespace Controller.Strategy
{
    public class StrategyCuisinier : IStrategy
    {
        public void Call(object instance, object[] args)
        {
            foreach (int plat in args)
            {
                DatabaseController.Instance.UpdateStock(plat);
            }

            //TODO : add cooking time
        }
    }
}