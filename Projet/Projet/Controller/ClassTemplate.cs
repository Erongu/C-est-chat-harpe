using System;

namespace Controller
{
    public class ClassTemplate : Builder
    {
        public ClassTemplate(IStrategy strategy) : base(strategy) { }
    }
}