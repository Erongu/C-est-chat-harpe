using Controller.Network.Server;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Model;
using System.Data.SqlClient;
using Projet.Controller;

namespace Controller
{
    class RestaurantController
    {

        private static View.Restaurant vue;
        private static List<Personnel> personnels;
        private static Restaurant restaurant;
        static void Main(string[] args)
        {
            restaurant = new Factory().Create<Restaurant>();
            
            Random rand = new Random();

            Thread.Sleep(1);

            vue = new View.Restaurant();
            vue.Show();

            Instanciation();

            Personnel serveur = new Factory().Create<Personnel>(new Dictionary<string, object> { { "id", 0 }, { "prenom", "Muhammed" }, { "nom", "Albani" }, { "metier", 1 }, { "posx", 3 }, { "posy", 1 } });

            

            NetworkController.Instance.Start("127.0.0.1", 8500);

            var client = new Network.Client.Client();
            client.Connect("127.0.0.1", 8500);

            Console.WriteLine("====");

            serveur.method("Serve", new object[5] { serveur.PosX, serveur.PosY, 10, 4, restaurant.Map });

            List<Client> peps = new List<Client>() { };

            while (true)
            {
                Thread.Sleep(10);

                //Generate group
                Thread.Sleep(rand.Next(100, 301));

                Client pep = new Factory().Create<Client>();
                peps.Add(pep);

                Application.DoEvents();
            }


        }

        static private void runMaitreHotel(object id)
        {

        }

        static private void runChefRang(object id)
        {

        }

        static private void runServeur(object id)
        {
            Thread.Sleep(3000);
            Console.WriteLine(personnels[(int)id].PosX);
            personnels[(int)id].method("Serve", new object[5] { personnels[(int)id].PosX, personnels[(int)id].PosY, 7, 9, restaurant.Map });
            Console.WriteLine(personnels[(int)id].PosX);
        }

        static private void runCommis(object id)
        {

            
        }

        static private void runChef(object id)
        {

        }

        static private void runChefPlat(object id)
        {

        }

        static private void runCommisCuisine(object id)
        {

        }

        static private void runPlongeur(object id)
        {

        }

        static private void runLaveVaisselle(object id)
        {

        }

        static private void runMachineLaver(object id)
        {

        }

        static private void runFour(object id)
        {

        }

        static private void runPlaque(object id)
        {

        }

        static private void runView(object id)//Mise a jour de la vue
        {
            personnels = new List<Personnel>();
            vue.InitVue(personnels);

            while (1 == 1)
            {
                vue.UpdateVue(personnels);
                Thread.Sleep(33);
            }
            
        }

        static private void runGenerator(object id)
        {

        }

        private static void Instanciation()
        {
            SqlConnection connection;
            personnels = new List<Personnel>();
            try
            {
                // Build connection string
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "10.176.50.249";   // update me
                builder.UserID = "chef";              // update me
                builder.Password = "password";     // update me
                builder.InitialCatalog = "resto";

                // Connect to SQL
                Console.Write("Connecting to SQL Server ... ");
                using (connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();//Ouverture de la connection
                    Console.WriteLine("Done.");
                    Console.WriteLine("Chargement des personnages :");

                    SqlCommand command = connection.CreateCommand();//Création de la commande
                    command.CommandText = "SELECT * FROM personnel";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // while there is another record present
                        int i = 0;
                        while (reader.Read())
                        {
                            int result;
                            int.TryParse(reader[4].ToString(), out result);
                            //Instance des personnage
                            Thread th;
                            if (result == 1)//Construction d'un serveur
                            {
                                Console.WriteLine("Creation d'un serveur");
                                Personnel serveur = new Factory().Create<Personnel>(new Dictionary<string, object> { { "id", i }, { "prenom", reader[1] }, { "nom", reader[2] }, { "metier", reader[4] }, { "posx", 3 }, { "posy", 9 } });
                                personnels.Add(serveur);
                                th = new Thread(new ParameterizedThreadStart(runServeur));
                                th.Start(i);
                            }
                            else if (result == 2)//Maitre d'hotel
                            {
                                Console.WriteLine("Creation d'un Maitre d'Hotel");
                                Personnel mHotel = new Factory().Create<Personnel>(new Dictionary<string, object> { { "id", i }, { "prenom", reader[1] }, { "nom", reader[2] }, { "metier", reader[4] }, { "posx", 3 }, { "posy", 1 } });
                                personnels.Add(mHotel);
                                th = new Thread(new ParameterizedThreadStart(runMaitreHotel));
                                th.Start(i);
                            }
                            else if (result == 3)//Chef de rang
                            {
                                Console.WriteLine("Creation d'un Chef de Rang");
                                Personnel cRang = new Factory().Create<Personnel>(new Dictionary<string, object> { { "id", i }, { "prenom", reader[1] }, { "nom", reader[2] }, { "metier", reader[4] }, { "posx", 3 }, { "posy", 1 } });
                                personnels.Add(cRang);
                                th = new Thread(new ParameterizedThreadStart(runChefRang));
                                th.Start(i);
                            }
                            else if (result == 4)//Commis salle
                            {
                                Console.WriteLine("Creation d'un Commis de salle");
                                Personnel cSalle = new Factory().Create<Personnel>(new Dictionary<string, object> { { "id", i }, { "prenom", reader[1] }, { "nom", reader[2] }, { "metier", reader[4] }, { "posx", 0 }, { "posy", 0 } });
                                personnels.Add(cSalle);
                                th = new Thread(new ParameterizedThreadStart(runCommis));
                                th.Start(i);
                            }
                            else if (result == 5)//Chef cuisto
                            {
                                Console.WriteLine("Creation d'un Chef");
                                Personnel cCuisto = new Factory().Create<Personnel>(new Dictionary<string, object> { { "id", i }, { "prenom", reader[1] }, { "nom", reader[2] }, { "metier", reader[4] }, { "posx", 3 }, { "posy", 3 } });
                                personnels.Add(cCuisto);
                                th = new Thread(new ParameterizedThreadStart(runChef));
                                th.Start(i);
                            }
                            else if (result == 6)//Chef de partie
                            {
                                Console.WriteLine("Creation d'un Chef de Partie");
                                Personnel cPartie = new Factory().Create<Personnel>(new Dictionary<string, object> { { "id", i }, { "prenom", reader[1] }, { "nom", reader[2] }, { "metier", reader[4] }, { "posx", 3 }, { "posy", 1 } });
                                personnels.Add(cPartie);
                                th = new Thread(new ParameterizedThreadStart(runChefPlat));
                                th.Start(i);
                            }
                            else if (result == 7)//Commis de cuisine
                            {
                                Console.WriteLine("Creation d'un Commis en cuisine");
                                Personnel cCuisine = new Factory().Create<Personnel>(new Dictionary<string, object> { { "id", i }, { "prenom", reader[1] }, { "nom", reader[2] }, { "metier", reader[4] }, { "posx", 3 }, { "posy", 1 } });
                                personnels.Add(cCuisine);
                                th = new Thread(new ParameterizedThreadStart(runCommisCuisine));
                                th.Start(i);
                            }
                            else if (result == 7)//Plongeur
                            {
                                Console.WriteLine("Creation d'un Plongeur");
                                Personnel plongeur = new Factory().Create<Personnel>(new Dictionary<string, object> { { "id", i }, { "prenom", reader[1] }, { "nom", reader[2] }, { "metier", reader[4] }, { "posx", 3 }, { "posy", 1 } });
                                personnels.Add(plongeur);
                                th = new Thread(new ParameterizedThreadStart(runPlongeur));
                                th.Start(i);
                            }
                            i++;
                        }
                    }
                    connection.Close();//Fermeture de la connection
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            //Partie de l'instanciation des machines


            //Partie d'instanciation de la vue
            Thread vueThread = new Thread(runView);
            vueThread.Start();
        }
    }
}