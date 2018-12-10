using Model;
using System.Collections.Generic;

namespace Controller
{
    public interface IStrategy
    {
        void method(Personnel instance, object[] args);
    }

    public class Builder
    {
        readonly Dictionary<string, IStrategy> strategies;

        public Builder(Dictionary<string, IStrategy> strategies, Dictionary<string, object> args)
        {
            this.strategies = strategies;
        }

        public void method(string key, object[] args)
        {
            this.strategies[key].method(this, args);
        }
    }
}
