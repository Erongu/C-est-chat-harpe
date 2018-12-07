using System;
using System.Reflection;
namespace Controller
{
    public interface IStrategy
    {
        void method();
    }

    public class Builder
    {
        readonly IStrategy strategy;

        public Builder(IStrategy strategy) => this.strategy = strategy;

        public void method() => strategy.method();
    }
}
