using Controller.Strategy.Cuisine;
using Controller.Strategy.Salle;
using System;
using System.Collections.Generic;
using Model.Salle;

namespace Controller.Strategy
{
    public class Factory
    {
        public Factory() { }

        public T Create<T>(Dictionary<string, object> args = null)
        {
            Dictionary<string, IStrategy> strategies;

            if (typeof(T).Name == "Personnel")
            {
                strategies = new Dictionary<string, IStrategy>()
                                            {
                                                {"Move", new StrategyServeur()},
                                                {"ChooseTable", new StrategyMaitreRang()},
                                                {"Cook", new StrategyCuisinier()}
                                            };
            }
            else
            {
                strategies = new Dictionary<string, IStrategy>() { };
            }

            return (T)Activator.CreateInstance(typeof(T), strategies, args );
        }
    }
}