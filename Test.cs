using System;
namespace Test
{
    public class Test
    {
        public int miaou { get => miaou; set => miaou = value; }

        public void Test()
        {
            this.miaou = 2;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(this.miaou);
        }
    }
    
}