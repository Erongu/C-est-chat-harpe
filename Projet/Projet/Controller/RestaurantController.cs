using Controller.Network.Server;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Model;
using System.Data.SqlClient;
using Controller;
using Controller.Strategy;
using Model.Enums;
using Model.Salle;

namespace Controller
{
    class RestaurantController
    {

        public static View.Restaurant Vue;

        private static Restaurant restaurant;
        private static Random random = new Random();

        private static List<Personnel> personnels = new List<Personnel>();
        private static List<Client> clients = new List<Client>() { };

        public static Network.Client.Client Client = new Network.Client.Client();

        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            restaurant = new Factory().Create<Restaurant>();
            
            Thread.Sleep(1);

            Vue = new View.Restaurant();
            Vue.Show();

            Personnel serveur = new Factory().Create<Personnel>(new Dictionary<string, object> { { "id", 0 }, { "prenom", "Muhammed" }, { "nom", "Albani" }, { "metier", 1 }, { "posx", 3 }, { "posy", 1 } });

            //DatabaseController.Instance.Initialize("10.176.50.249", "chef", "password", "resto");
            MapController.Instance.Initialize();
            personnels.Add(serveur);
            SpawnNpc();

            NetworkController.Instance.Start("127.0.0.1", 8500);
            Client.Connect("127.0.0.1", 8500);

            LogController.Instance.Info("Initialisation terminé.");


            while (true) // Loop Logic
            {
                Thread.Sleep(1);

                Loop(); // On mets tout ce qui doit être en temps réel dans cette fonction

                Application.DoEvents();
            }


        }

        static private void Loop()
        {
            // Generate group
            // Thread.Sleep(random.Next(100, 301)); On évite les Thread Sleep, ça casse tout le temps réel

            clients.Add(new Factory().Create<Client>());

            Vue.UpdateVue(personnels);
        }

        static private void RunMaitreHotel(object id)
        {

        }

        static private void RunChefRang(object id)
        {

        }

        static private void RunServeur(object id)
        {
            while (true)
            {
                personnels[(int)id].Call("Serve", new object[4] { personnels[(int)id].PosX, personnels[(int)id].PosY, random.Next(0, 15), random.Next(0, 40) });

                Thread.Sleep(5000);
            }

        }

        static private void RunCommis(object id)
        {

            
        }

        static private void RunChef(object id)
        {

        }

        static private void RunChefPlat(object id)
        {

        }

        static private void RunCommisCuisine(object id)
        {

        }

        static private void RunPlongeur(object id)
        {

        }

        static private void RunLaveVaisselle(object id)
        {

        }

        static private void RunMachineLaver(object id)
        {

        }

        static private void RunFour(object id)
        {

        }

        static private void RunPlaque(object id)
        {

        }

        static private void RunView() // Mise a jour de la vue
        {
            Vue.InitVue(personnels);           
        }

        static private void RunGenerator(object id)
        {

        }

        private static void SpawnNpc()
        {
            LogController.Instance.Info("Génération des NPCs");

            //personnels = DatabaseController.Instance.GetPersonnels();

            if (personnels == null)
                return;

            foreach(var personnel in personnels)
            {
                Thread thread = null;

                switch (personnel.Metier)
                {
                    case (int)PersonnelEnums.Serveur:
                        thread = new Thread(new ParameterizedThreadStart(RunServeur));
                        break;
                    case (int)PersonnelEnums.Maitre_Hotel:
                        thread = new Thread(new ParameterizedThreadStart(RunMaitreHotel));
                        break;
                    case (int)PersonnelEnums.Chef_Rang:
                        thread = new Thread(new ParameterizedThreadStart(RunChefRang));
                        break;
                    case (int)PersonnelEnums.Commis_Salle:
                        thread = new Thread(new ParameterizedThreadStart(RunCommis));
                        break;
                    case (int)PersonnelEnums.Chef_Cuisto:
                        thread = new Thread(new ParameterizedThreadStart(RunChef));
                        break;
                    case (int)PersonnelEnums.Chef_Partie:
                        thread = new Thread(new ParameterizedThreadStart(RunChefPlat));
                        break;
                    case (int)PersonnelEnums.Commis_Cuisine:
                        thread = new Thread(new ParameterizedThreadStart(RunCommisCuisine));
                        break;
                    case (int)PersonnelEnums.Plongeur:
                        thread = new Thread(new ParameterizedThreadStart(RunPlongeur));
                        break;
                }

                thread.Start(personnel.ID);
            }

            Thread vueThread = new Thread(RunView);
            vueThread.Start();
        }
    }
}