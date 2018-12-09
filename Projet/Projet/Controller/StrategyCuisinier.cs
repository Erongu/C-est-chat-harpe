using System;
namespace Controller
{
    public class StrategyCuisinier : IStrategy
    {
        public void method(object[] args)
        {
            Console.WriteLine("Le cuisinier cuisine");
        }
    }
}