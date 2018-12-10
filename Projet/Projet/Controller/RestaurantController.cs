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
        private static List<Personnel> personnels = new List<Personnel>();

        static void Main(string[] args)
        {
            //Instanciation();

            vue = new View.Restaurant();
            vue.Show();

            Random rand = new Random();
            
            Personnel serveur = new Factory().Create<Personnel>(new Dictionary<string, object> { { "id", 0 }, { "prenom", "Muhammed" }, { "nom", "Albani" }, { "metier", "serveur" }, { "posx", 3 }, { "posy", 1 } });
            Restaurant restaurant = new Factory().Create<Restaurant>();
            MapController.Instance.Initialize();

            NetworkController.Instance.Start("127.0.0.1", 8500);

            var client = new Network.Client.Client();
            client.Connect("127.0.0.1", 8500);

            Console.WriteLine("====");

            serveur.method("Serve", new object[5] { serveur.PosX, serveur.PosY, 10, 4, restaurant.Map });

            List<Client> peps = new List<Client>() { };

            while (true)
            {
                //Generate group
                Thread.Sleep(rand.Next(100,301));

                Client pep = new Factory().Create<Client>();
                peps.Add(pep);

                Thread.Sleep(1);
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
            while (1 == 1)
            {
                Console.WriteLine("Je suis le serveur : " + id);
                Thread.Sleep(1000);
            }
        }

        static private void runCommis(object id)
        {
            
        }

        static private void runChef(object id)
        {

        }

        static private void runChefPatissier(object id)
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

        static private void runView(object id)
        {

        }

        static private void runGenerator(object id)
        {

        }

        private static void Instanciation()
        {
            SqlConnection connection;
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
                    Console.WriteLine("Chargement des personnage");

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
                            Console.WriteLine(result);
                            //Instance des personnage
                            Thread th;
                            if (result == 1)//Construction d'un serveur //ERREUR ICIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII
                            {
                                Console.WriteLine("Creation serveur");
                                Personnel serveur = new Factory().Create<Personnel>(new Dictionary<string, object> { { "id", i }, { "prenom", reader[1] }, { "nom", reader[2] }, { "metier", reader[3] }, { "posx", 3 }, { "posy", 1 } });
                                personnels.Add(serveur);
                                th = new Thread(new ParameterizedThreadStart(runServeur));
                                th.Start(i);
                            }
                            else if (reader[3] == "maitre hotel")
                            {
                                Model.Personnel serveur = new Factory().Create<Model.Personnel>();
                                //serveur.method("Serve", null); // change argument
                                personnels.Add(serveur);
                                th = new Thread(new ParameterizedThreadStart(runMaitreHotel));
                                th.Start(i);
                            }
                            else if (reader[3] == "chef de rang")
                            {
                                Model.Personnel serveur = new Factory().Create<Model.Personnel>();
                                //serveur.method("Serve", null); // change argument
                                personnels.Add(serveur);
                                th = new Thread(new ParameterizedThreadStart(runChefRang));
                                th.Start(i);
                            }
                            else if (reader[3] == "commis de salle")
                            {
                                Model.Personnel serveur = new Factory().Create<Model.Personnel>();
                                //serveur.method("Serve", null); // change argument
                                personnels.Add(serveur);
                                th = new Thread(new ParameterizedThreadStart(runCommis));
                                th.Start(i);
                            }
                            else if (reader[3] == "chef de cuisine")
                            {
                                Model.Personnel serveur = new Factory().Create<Model.Personnel>();
                                //serveur.method("Serve", null); // change argument
                                personnels.Add(serveur);
                                th = new Thread(new ParameterizedThreadStart(runChefPlat));
                                th.Start(i);
                            }
                            else if (reader[3] == "commis de cuisine")
                            {
                                Model.Personnel serveur = new Factory().Create<Model.Personnel>();
                                //serveur.method("Serve", null); // change argument
                                personnels.Add(serveur);
                                th = new Thread(new ParameterizedThreadStart(runCommisCuisine));
                                th.Start(i);
                            }
                            else if (reader[3] == "plongeur")
                            {
                                Model.Personnel serveur = new Factory().Create<Model.Personnel>();
                                //serveur.method("Serve", null); // change argument
                                personnels.Add(serveur);
                                th = new Thread(new ParameterizedThreadStart(runPlongeur));
                                th.Start(i);
                            }

                        }
                    }
                    connection.Close();//Fermeture de la connection
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
