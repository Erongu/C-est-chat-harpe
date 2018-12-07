using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    class RestaurantController
    {
        static void Main(string[] args)
        {
            Factory factory = new Factory("Serveur");

            object serveur = factory.CreateObject(new string[0], new Type[0]);
            Console.WriteLine("====");
            string[] MethodNames = serveur.GetType().GetMethods().Select(I => I.Name).ToArray();
            foreach (string method in MethodNames)
            {
                Console.WriteLine(method);
            }
            serveur.method();
            Console.WriteLine("====");
            Console.WriteLine(serveur.GetType());
            Console.WriteLine("IZI");
            Console.ReadKey(true);
        }
    }
}
