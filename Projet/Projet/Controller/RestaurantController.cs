using Projet.Controller.Network.Server;
using System;
using System.Threading;
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

            serveur.method("Serve");

            while (true)
            {
                Thread.Sleep(10);
                Application.DoEvents();
            }


        }
    }
}
