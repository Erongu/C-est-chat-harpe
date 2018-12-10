using System;
namespace Controller
{
    public class StrategyCuisinier : IStrategy
    {
        public void method(object instance, object[] args)
        {
            Console.WriteLine("Le cuisinier cuisine");
        }
    }
}