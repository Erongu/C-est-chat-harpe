using System.Collections.Generic;

namespace Controller
{
    public class ClassTemplate : Builder
    {
        public ClassTemplate(Dictionary<string, IStrategy> strategies, Dictionary<string, object> args) : base(strategies, args) { }
    }
}