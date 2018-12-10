using Controller.Network.Server;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Model;

namespace Controller
{
    class RestaurantController
    {

        private static View.Restaurant vue;

        static void Main(string[] args)
        {
            vue = new View.Restaurant();
            vue.Show();

            Personnel serveur = new Factory().Create<Personnel>(new Dictionary<string, object> { { "id", 0 }, { "prenom", "Muhammed" }, { "nom", "Albani" }, { "metier", "serveur" }, { "posx", 3 }, { "posy", 1 } });
            Restaurant restaurant = new Factory().Create<Restaurant>();

            NetworkController.Instance.Start("127.0.0.1", 8500);

            var client = new Network.Client.Client();
            client.Connect("127.0.0.1", 8500);

            Console.WriteLine("====");

            serveur.method("Serve", new object[5] { serveur.PosX, serveur.PosY, 10, 4, restaurant.Map });

            while (true)
            {
                Thread.Sleep(10);
                Application.DoEvents();
            }


        }
    }
}
