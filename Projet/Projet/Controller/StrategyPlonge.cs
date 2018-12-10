using System;
namespace Controller
{
    public class StrategyPlonge : IStrategy
    {
        public void method(object instance, object[] args)
        {
            Console.WriteLine("Le cuisinier cuisine");
        }
    }
}