using Model;
namespace Controller
{
    public class StrategyCuisinier : IStrategy
    {
        public void method(object instance, object[] args)
        {
            BDD databaseConnection = new BDD();
            foreach (int plat in args)
            {
                databaseConnection.UpdateStock(plat);
            }
        }
    }
}