using System.Collections.Generic;

namespace Controller
{
    public interface IStrategy
    {
        void method();
    }

    public class Builder
    {
        readonly Dictionary<string, IStrategy> strategies;

        public Builder(Dictionary<string, IStrategy> strategies)
        {
            this.strategies = strategies;
        }

        public void method(string key)
        {
            this.strategies[key].method();
        }
    }
}
