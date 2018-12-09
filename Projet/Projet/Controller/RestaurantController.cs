using Projet.Controller.Network.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using View;

namespace Controller
{
    class RestaurantController
    {

        private static View.Restaurant vue;

        static void Main(string[] args)
        {
            vue = new View.Restaurant();
            vue.Show();

            Personnel serveur = new Factory().Create<Personnel>();

            NetworkController.Instance.Start("127.0.0.1", 8500);

            var client = new Projet.Controller.Network.Client.Client();
            client.Connect("127.0.0.1", 8500);

            Console.WriteLine("====");

            string[] MethodNames = serveur.GetType().GetMethods().Select(I => I.Name).ToArray();

            foreach (string method in MethodNames)
            {
                Console.WriteLine(method);
            }

            serveur.method("Serve");
            Console.WriteLine("====");
            Console.WriteLine(serveur.GetType());


            while (true)
            {
                Thread.Sleep(10);
                Application.DoEvents();
            }


        }
    }
}
