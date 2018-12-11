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
                                                {"Serve", new StrategyServeur()},
                                                {"ChooseTable", new StrategyMaitreHotel()}
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