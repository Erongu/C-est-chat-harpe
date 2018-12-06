using System;
namespace Controller
{
    public class StrategyServeur : IStrategy
    {
        public void method()
        {
            Console.WriteLine("Le serveur bouge");
        }
    }
}