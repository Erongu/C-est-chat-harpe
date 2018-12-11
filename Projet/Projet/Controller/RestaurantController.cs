using Controller.Network.Server;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Model;
using Controller.Strategy;
using Model.Enums;
using Model.Salle;
using System.Linq;
using System.Reflection;
using Model.Threading;

namespace Controller
{
    class RestaurantController
    {
        public static double Vitesse = 1.0;
        public static View.Restaurant Vue;

        private static Restaurant restaurant;
        private static AsyncRandom random = new AsyncRandom();

        private static List<Personnel> personnels = new List<Personnel>();
        private static List<Groupe> groupes = new List<Groupe>() { };

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
            Personnel maitre_hotel = new Factory().Create<Personnel>(new Dictionary<string, object> { { "id", 1 }, { "prenom", "Muhammed" }, { "nom", "Albani" }, { "metier", 2 }, { "posx", 4 }, { "posy", 21 } });

            //DatabaseController.Instance.Initialize("10.176.50.249", "chef", "password", "resto");
            MapController.Instance.Initialize();
            personnels.Add(serveur);
            personnels.Add(maitre_hotel);

            NetworkController.Instance.Start("127.0.0.1", 8500);
            Client.Connect("127.0.0.1", 8500);

            LogController.Instance.Info("Initialisation terminé.");

            SpawnNpc();
            StartThreads();

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

            // clients.Add(new Factory().Create<Client>());
            Vue.UpdateVue(personnels);
        }

        public static void AddGroupe()
        {
            var groupe = new Factory().Create<Groupe>();
            groupes.Add(groupe);
        }

        private static void StartThreads()
        {
            foreach (MethodInfo methodRun in typeof(RestaurantController).GetMethods(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance))
            {
                if (methodRun.Name.StartsWith("Run"))
                {
                    Action action = (Action)Delegate.CreateDelegate(typeof(Action), methodRun);
                    Thread thread = new Thread(new ThreadStart(action));

                    thread.Start();
                }
            }

        }

        static private void RunMaitreHotel()
        {
            LogController.Instance.Debug("Start Thread on Id: " + Thread.CurrentThread.ManagedThreadId);

            List<Groupe> groupeMAJ = new List<Groupe>();

            while (true)
            {
                var maitresDhotels = personnels.Where(x => x.Metier == (int)PersonnelEnums.Maitre_Hotel);
                

                foreach (var mHotel in maitresDhotels)
                {
                    //Comparaison liste groupe
                    if(groupeMAJ != groupes)
                    {

                    }

                }
            }
        }

        static private void RunChefRang()
        {
            LogController.Instance.Debug("Start Thread on Id: " + Thread.CurrentThread.ManagedThreadId);

            while (true)
            {
                var chefsRangs = personnels.Where(x => x.Metier == (int)PersonnelEnums.Chef_Rang);

                foreach (var cRang in chefsRangs)
                {

                }
            }
        }

        static private void RunServeurs()
        {
            LogController.Instance.Debug("Start Thread on Id: " + Thread.CurrentThread.ManagedThreadId);

            var serveurs = personnels.Where(x => x.Metier == (int)PersonnelEnums.Serveur);

            var taskPool = new TaskPool("Serveurs TaskPool", 100);
            taskPool.Start();

            foreach (var serveur in serveurs)
            {
                var cell = MapController.Instance.GetRandomFreeCell();

                taskPool.CallPeriodically(5000, () =>
                {
                    serveur.Call("Move", new object[4] { serveur.PosX, serveur.PosY, cell.X, cell.Y });
                });                
            }
        }

        static private void RunCommis()
        {
            LogController.Instance.Debug("Start Thread on Id: " + Thread.CurrentThread.ManagedThreadId);

            while (true)
            {
                var commisSalle = personnels.Where(x => x.Metier == (int)PersonnelEnums.Commis_Salle);

                foreach (var cSalle in commisSalle)
                {

                }

            }
        }

        static private void RunChef()
        {
            LogController.Instance.Debug("Start Thread on Id: " + Thread.CurrentThread.ManagedThreadId);

            while (true)
            {
                var chefCuistos = personnels.Where(x => x.Metier == (int)PersonnelEnums.Chef_Cuisto);

                foreach (var cCuisto in chefCuistos)
                {

                }

            }
        }

        static private void RunChefPlat()
        {
            LogController.Instance.Debug("Start Thread on Id: " + Thread.CurrentThread.ManagedThreadId);

            while (true)
            {
                var chefPlats = personnels.Where(x => x.Metier == (int)PersonnelEnums.Chef_Partie);

                foreach (var cPlats in chefPlats)
                {

                }

            }
        }

        static private void RunCommisCuisine()
        {
            LogController.Instance.Debug("Start Thread on Id: " + Thread.CurrentThread.ManagedThreadId);

            while (true)
            {
                var commisCuisine = personnels.Where(x => x.Metier == (int)PersonnelEnums.Commis_Cuisine);

                foreach (var cCuisine in commisCuisine)
                {

                }

            }
        }

        static private void RunPlongeur()
        {
            LogController.Instance.Debug("Start Thread on Id: " + Thread.CurrentThread.ManagedThreadId);

            while (true)
            {
                var plongeurs = personnels.Where(x => x.Metier == (int)PersonnelEnums.Plongeur);

                foreach (var plongeur in plongeurs)
                {

                }

            }
        }

        static private void RunLaveVaisselle()
        {

        }

        static private void RunMachineLaver()
        {

        }

        static private void RunFour()
        {

        }

        static private void RunPlaque()
        {

        }

        private static void SpawnNpc()
        {
            LogController.Instance.Info("Génération des NPCs");
            //personnels = DatabaseController.Instance.GetPersonnels();

            Vue.InitVue(personnels);
        }
    }
}