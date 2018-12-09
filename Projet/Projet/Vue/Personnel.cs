using System.Collections.Generic;
using Controller;

namespace View
{
    public class Personnel : ClassTemplate
    {
        public Personnel(Dictionary<string, IStrategy> strategies) : base(strategies)
        {
        }
    }
}