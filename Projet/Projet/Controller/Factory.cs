namespace Controller
{
    public class Factory
    {
        public Factory()
        {

        }
        public override MyClass createClass()
        {
            return new MyClass();
        }

        public class MyCLass : ClassTemplate { }
    }
}