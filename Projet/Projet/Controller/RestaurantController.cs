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
            Console.WriteLine("IZII");
            Factory factory = new Factory("Serveur"); 

            serveur = factory.CreateObject();

            Console.WriteLine(serveur.GetType());
            Console.WriteLine("IZI");
            Console.ReadKey(true);
        }
    }
}
