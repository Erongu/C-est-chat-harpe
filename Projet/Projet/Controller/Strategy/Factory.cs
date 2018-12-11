using Controller.Strategy.Cuisine;
using Controller.Strategy.Salle;
using System;
using System.Collections.Generic;

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
                                                {"ChooseTable", new StrategyMaitreHotel()},
                                                {"Cook", new StrategyCuisinier()},
                                                {"Plonge", new StrategyPlonge()},
                                                {"Lave", new StrategyLavage()}
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