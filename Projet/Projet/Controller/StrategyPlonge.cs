using System;
namespace Controller
{
    public class StrategyPlonge : IStrategy
    {
        public void method(object[] args)
        {
            Console.WriteLine("Le plongeur plonge");
        }
    }
}