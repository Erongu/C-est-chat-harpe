using Model;
using Model.Threading;
using System.Collections.Generic;

namespace Controller.Strategy
{
    public interface IStrategy
    {
        void Call(object instance, object[] args);
    }

    public class Builder
    {
        readonly Dictionary<string, IStrategy> strategies;

        public Builder(Dictionary<string, IStrategy> strategies, Dictionary<string, object> args)
        {
            this.strategies = strategies;
        }

        public void Call(string key, object[] args)
        {
            this.strategies[key].Call(this, args);
        }
    }
}
