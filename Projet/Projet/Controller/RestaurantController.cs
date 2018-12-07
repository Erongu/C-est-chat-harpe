using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using View;

namespace Controller
{
    class RestaurantController
    {

        private static View.Restaurant vue;

        static void Main(string[] args)
        {
            vue = new View.Restaurant();
            vue.ShowDialog();
            Console.ReadKey(true);

            Factory factory = new Factory("Serveur");

            object serveur = factory.CreateObject(new string[0], new Type[0]);
            Console.WriteLine("====");
            string[] MethodNames = serveur.GetType().GetMethods().Select(I => I.Name).ToArray();
            foreach (string method in MethodNames)
            {
                Console.WriteLine(method);
            }
            Console.WriteLine("====");
            Console.WriteLine(serveur.GetType());
            

            
        }
    }
}
