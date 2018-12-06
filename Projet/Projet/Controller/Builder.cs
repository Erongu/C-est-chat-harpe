using System;
using System.Reflection;
namespace Controller
{
    public class Builder
    {
        readonly object strategy;
        
        public Builder()
        {
            string type = this.GetType().Name;
            Console.WriteLine(type);
            if(type == "Serveur")
            {
                object strategy = new StrategyServeur();
            }
        }

        public void method() {
            strategy.method();
        };
    }
}