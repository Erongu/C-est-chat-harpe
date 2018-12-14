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
using Projet.Model.Personnel;
using Model.Cuisine;

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

            Personnel serveur = new Factory().Create<Personnel>(new Dictionary<string, object> { { "id", 0 }, { "prenom", "Muhammed" }, { "nom", "Albani" }, { "metier", 1 }, { "posx", 7 }, { "posy", 17 }, { "carre", 1 } });
            Personnel serveur2 = new Factory().Create<Personnel>(new Dictionary<string, object> { { "id", 11 }, { "prenom", "Muhammed" }, { "nom", "Albani" }, { "metier", 1 }, { "posx", 7 }, { "posy", 17 }, { "carre", 2 } });
            Personnel maitre_hotel = new Factory().Create<Personnel>(new Dictionary<string, object> { { "id", 1 }, { "prenom", "Muhammed" }, { "nom", "Albani" }, { "metier", 2 }, { "posx", 4 }, { "posy", 21 } });
            Personnel maitre_de_rang1 = new Factory().Create<Personnel>(new Dictionary<string, object> { { "id", 2 }, { "prenom", "Carre1" }, { "nom", "Albani" }, { "metier", 3 }, { "posx", 7 }, { "posy", 19 }, { "carre", 1 } });
            Personnel maitre_de_rang2 = new Factory().Create<Personnel>(new Dictionary<string, object> { { "id", 3 }, { "prenom", "Carre2" }, { "nom", "Albani" }, { "metier", 3 }, { "posx", 8 }, { "posy", 19 }, { "carre", 2 } });
            Personnel chefcuisto = new Factory().Create<Personnel>(new Dictionary<string, object> { { "id", 4 }, { "prenom", "Chef" }, { "nom", "Albani" }, { "metier", 5 }, { "posx", 5 }, { "posy", 2 }, { "carre", 4 } });
            Personnel chefpartie1 = new Factory().Create<Personnel>(new Dictionary<string, object> { { "id", 5 }, { "prenom", "Chef" }, { "nom", "Albani" }, { "metier", 6 }, { "posx", 6 }, { "posy", 1 }, { "carre", 4 } });
            Personnel chefpartie2 = new Factory().Create<Personnel>(new Dictionary<string, object> { { "id", 6 }, { "prenom", "Chef" }, { "nom", "Albani" }, { "metier", 6 }, { "posx", 7 }, { "posy", 1 }, { "carre", 4 } });
            Personnel commiscuisine1 = new Factory().Create<Personnel>(new Dictionary<string, object> { { "id", 7 }, { "prenom", "Chef" }, { "nom", "Albani" }, { "metier", 7 }, { "posx", 7 }, { "posy", 2 }, { "carre", 4 } });
            Personnel commiscuisine2 = new Factory().Create<Personnel>(new Dictionary<string, object> { { "id", 8 }, { "prenom", "Chef" }, { "nom", "Albani" }, { "metier", 7 }, { "posx", 7 }, { "posy", 2 }, { "carre", 4 } });
            Personnel plongeur = new Factory().Create<Personnel>(new Dictionary<string, object> { { "id",9 }, { "prenom", "Chef" }, { "nom", "Albani" }, { "metier", 8 }, { "posx", 9 }, { "posy", 1 }, { "carre", 4 } });
            Personnel commisalle = new Factory().Create<Personnel>(new Dictionary<string, object> { { "id", 10 }, { "prenom", "Chef" }, { "nom", "Albani" }, { "metier", 4 }, { "posx", 9 }, { "posy", 19 }, { "carre", 4 } });


            //DatabaseController.Instance.Initialize("10.176.50.249", "chef", "password", "resto");
            MapController.Instance.Initialize();
            personnels.Add(serveur);
            personnels.Add(maitre_hotel);
            personnels.Add(maitre_de_rang1);
            personnels.Add(maitre_de_rang2);
            personnels.Add(chefcuisto);
            personnels.Add(chefpartie1);
            personnels.Add(chefpartie2);
            personnels.Add(commiscuisine1);
            personnels.Add(commiscuisine2);
            personnels.Add(plongeur);
            personnels.Add(commisalle);
            personnels.Add(serveur2);

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

        //Ajout d'un groupe
        public static void AddGroupe()
        {
            var groupe = new Factory().Create<Groupe>();
            groupes.Add(groupe);
        }

        //Lancement des thread
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

        static private void RunMaitreHotel()//Fini
        {
            LogController.Instance.Debug("Start Thread on Id: " + Thread.CurrentThread.ManagedThreadId);

            List<Groupe> groupeMAJ = new List<Groupe>();

            while (true)
            {
                var maitresDhotels = personnels.Where(x => x.Metier == (int)PersonnelEnums.Maitre_Hotel);
                

                foreach (var mHotel in maitresDhotels)
                {
                    //Comparaison liste groupe
                    Groupe grp = MaitreHotel.CheckNouveauGroupe(groupeMAJ, groupes);//On regarde si il y'a un nouveau groupe
                    if (grp != null)
                    {
                        groupeMAJ.Add(grp);//On ajoute le groupe a la liste
                        Table tbl = MaitreHotel.RechercheTable(restaurant.GetAllTables(), grp);
                        //On lui cherche une table
                        if (tbl != null)//Si il a bien trouvé une table
                        {
                            //On attribue un numéro de table au groupe
                            groupes[groupes.Count - 1].NumeroTable = tbl.Numero;
                            groupes[groupes.Count - 1].NumeroRang = tbl.Rang;
                            groupes[groupes.Count - 1].NumeroCarre = tbl.Carre;

                            //On appel le maitre de rang coresspondant au carre de la table
                            Console.WriteLine("Le maitre d'hotel a trouver la table : " + tbl.Numero + " pour le groupe de " + grp.Taille);
                            foreach(Personnel personnel in personnels)
                            {
                                if((personnel.Metier == (int)PersonnelEnums.Chef_Rang)&&(personnel.Carre == tbl.Carre))
                                {
                                    personnel.Groupe = groupes[groupes.Count - 1];
                                }
                            }

                        }
                        else//Si aucune table n'a été trouvé on enlève le groupe des deux listes
                        {
                            Console.WriteLine("Le maitre d'hotel n'a pas trouvé de table au groupe");
                            groupes.RemoveAt(groupes.Count - 1);
                            groupeMAJ.RemoveAt(groupeMAJ.Count - 1);
                        }
                    }

                }
            }
        }

        static private void RunChefRang()//Placage Fini //Envoie des commandes a finir
        {
            LogController.Instance.Debug("Start Thread on Id: " + Thread.CurrentThread.ManagedThreadId);

            while (true)
            {
                var chefsRangs = personnels.Where(x => x.Metier == (int)PersonnelEnums.Chef_Rang);

                foreach (var cRang in chefsRangs)
                {
                    //Si le chef de rang a un groupe a placer
                    if (cRang.Groupe != null)
                    {
                        //Il se déplace a la table
                        List<int> pos = Personnel.GetPosXTable(cRang.Groupe.NumeroTable, restaurant.GetAllTables());//On prend la position de la table
                        int SpawnX = cRang.PosX; int SpawnY = cRang.PosY;//On sauvegarde sa place d'origine
                        cRang.Call("Move", new object[4] { cRang.PosX, cRang.PosY, pos[0], pos[1] });//On deplace le chef de rang a la table
                        restaurant.GetCarre(cRang.Groupe.NumeroCarre).GetRang(cRang.Groupe.NumeroRang).GetTable(cRang.Groupe.NumeroTable).Groupe = cRang.Groupe;//On place le groupe a la table
                        Thread.Sleep(2000);
                        //On instancie le groupe
                        Thread th = new Thread(restaurant.GetCarre(cRang.Groupe.NumeroCarre).GetRang(cRang.Groupe.NumeroRang).GetTable(cRang.Groupe.NumeroTable).Groupe.RunGroupe);
                        th.Start();
                        cRang.Call("Move", new object[4] { cRang.PosX, cRang.PosY, SpawnX, SpawnY });//Le chef de rang retourne a sa place d'origine
                        cRang.Groupe = null;//On reset son groupe
                        Console.WriteLine("Le chef de rang a placé le groupe !");
                    }
                    else//Il s'occupe de prendre les commandes
                    {
                        foreach(Rang rang in restaurant.GetCarre(cRang.Carre).Rangs)//Pour tout les rangs dont le chef de rang s'occupe
                        {
                            foreach (Table table in rang.Tables){//Pour chaque table du rang
                                //On regarde si des clients on fini de commander
                                if(table.Groupe != null)
                                {
                                    if (table.Groupe.Etat == Groupe.GroupeEnum.CommandeEnd)
                                    {
                                        List<int> pos = Personnel.GetPosXTable(table.Numero, restaurant.GetAllTables());
                                        int SpawnX = cRang.PosX; int SpawnY = cRang.PosY;//On sauvegarde sa place d'origine
                                        cRang.Call("Move", new object[4] { cRang.PosX, cRang.PosY, pos[0], pos[1] });//On se déplace a la table
                                        List<Plat> plats = table.Groupe.Commande(); //On prend les commandes
                                        //On envoie les commandes a la cuisine
                                        cRang.Call("Move", new object[4] { cRang.PosX, cRang.PosY, SpawnX, SpawnY });//Le chef de rang retourne a sa place d'origine

                                    }
                                }
                                
                            }
                        }
                        
                    }
                }
            }
        }

        static private void RunServeurs()//Fini
        {
            LogController.Instance.Debug("Start Thread on Id: " + Thread.CurrentThread.ManagedThreadId);

            var serveurs = personnels.Where(x => x.Metier == (int)PersonnelEnums.Serveur);

            var taskPool = new TaskPool("Serveurs TaskPool", 100);
            taskPool.Start();

            foreach (var serveur in serveurs)
            {
                var cell = MapController.Instance.GetRandomFreeCell();
                
                    foreach (Rang rang in restaurant.GetCarre(serveur.Carre).Rangs) 
                    {
                        foreach (Table table in rang.Tables)
                        {
                            //Analyse du besoin de chaque table
                            if(table.Groupe != null)
                            {
                            if (table.Groupe.Etat == Groupe.GroupeEnum.AttenteEntree)//Si le groupe attend le plat
                            {
                                //Check comptoire
                                if (restaurant.Comptoir.CheckTable(table.Numero, table.Place, Plat.TypePlat.Entree))//Si on a bien tout les plats alors on les prend
                                {
                                    restaurant.Comptoir.GetPlat(table.Numero, Plat.TypePlat.Entree);//On prend les plats
                                    serveur.Call("Move", new object[4] { serveur.PosX, serveur.PosY, table.x, table.y });//On vas a la table
                                    restaurant.GetCarre(table.Carre).GetRang(table.Rang).GetTable(table.Numero).Groupe.Etat = Groupe.GroupeEnum.MangeEntree;//On met a jour le groupe
                                    serveur.Call("Move", new object[4] { serveur.PosX, serveur.PosY, 7, 17 });//On retourne au comptoir
                                }

                            }
                            if (table.Groupe.Etat == Groupe.GroupeEnum.AttentePlat)//Si le groupe attend le plat
                            {
                                //Check comptoire
                                if (restaurant.Comptoir.CheckTable(table.Numero, table.Place, Plat.TypePlat.Plat))//Si on a bien tout les plats alors on les prend
                                {
                                    restaurant.Comptoir.GetPlat(table.Numero, Plat.TypePlat.Plat);//On prend les plats
                                    serveur.Call("Move", new object[4] { serveur.PosX, serveur.PosY, table.x, table.y });//On vas a la table
                                    restaurant.GetCarre(table.Carre).GetRang(table.Rang).GetTable(table.Numero).Groupe.Etat = Groupe.GroupeEnum.MangePlat;//On met a jour le groupe
                                    serveur.Call("Move", new object[4] { serveur.PosX, serveur.PosY, 7, 17 });//On retourne au comptoir
                                }

                            }
                            if (table.Groupe.Etat == Groupe.GroupeEnum.AttenteDessert)//Si le groupe attend le dessert
                            {
                                //Check comptoire
                                if (restaurant.Comptoir.CheckTable(table.Numero, table.Place, Plat.TypePlat.Dessert))//Si on a bien tout les plats alors on les prend
                                {
                                    restaurant.Comptoir.GetPlat(table.Numero, Plat.TypePlat.Dessert);//On prend les plats
                                    serveur.Call("Move", new object[4] { serveur.PosX, serveur.PosY, table.x, table.y });//On vas a la table
                                    restaurant.GetCarre(table.Carre).GetRang(table.Rang).GetTable(table.Numero).Groupe.Etat = Groupe.GroupeEnum.MangeDessert;//On met a jour le groupe
                                    serveur.Call("Move", new object[4] { serveur.PosX, serveur.PosY, 7, 17 });//On retourne au comptoir
                                }

                            }
                            if (table.Groupe.Etat == Groupe.GroupeEnum.AttenteDePayer)//Si le groupe souhaite partir
                            {
                                serveur.Call("Move", new object[4] { serveur.PosX, serveur.PosY, table.x, table.y });//On vas a la table
                                Thread.Sleep(2000);//Remise au propre de la table
                                restaurant.GetCarre(table.Carre).GetRang(table.Rang).GetTable(table.Numero).Groupe = null;//On enlève ke groupe de la table
                                serveur.Call("Move", new object[4] { serveur.PosX, serveur.PosY, 7, 17 });//On retourne au comptoir
                            }

                        }
                            
                        }
                    }
                            
            }
        }

        static private void RunCommis()//Fini
        {
            LogController.Instance.Debug("Start Thread on Id: " + Thread.CurrentThread.ManagedThreadId);

            while (true)
            {
                var commisSalle = personnels.Where(x => x.Metier == (int)PersonnelEnums.Commis_Salle);

                foreach (var cSalle in commisSalle)
                {
                    List <Table> tables = restaurant.GetAllTables();
                    foreach(Table table in tables)
                    {
                        if(table.Groupe != null)//Si il y'a bien un groupe a la table
                        {
                            int nb = 1; if (table.Place > 5) { nb = 2; }//On set le nombre d'objet a set en fonction de la taille de la table
                            if ((table.Groupe.Pain == 0)&&(table.Groupe.Bouteille == 0))//Si il manque pain et bouteille
                            {
                                List<int> pos = Personnel.GetPosXTable(table.Numero, restaurant.GetAllTables());//On prend la position de la table
                                cSalle.Call("Move", new object[4] { cSalle.PosX, cSalle.PosY, table.x, table.y });
                                restaurant.GetCarre(table.Carre).GetRang(table.Rang).GetTable(table.Numero).Groupe.Pain = nb;
                                restaurant.GetCarre(table.Carre).GetRang(table.Rang).GetTable(table.Numero).Groupe.Bouteille = nb;
                            }
                            else if(table.Groupe.Pain == 0)//Si il manque du pain
                            {
                                List<int> pos = Personnel.GetPosXTable(table.Numero, restaurant.GetAllTables());//On prend la position de la table
                                cSalle.Call("Move", new object[4] { cSalle.PosX, cSalle.PosY, table.x, table.y });
                                restaurant.GetCarre(table.Carre).GetRang(table.Rang).GetTable(table.Numero).Groupe.Pain = nb;
                            }
                            else if (table.Groupe.Bouteille == 0)//Si il manque des bouteilles
                            {
                                List<int> pos = Personnel.GetPosXTable(table.Numero, restaurant.GetAllTables());//On prend la position de la table
                                cSalle.Call("Move", new object[4] { cSalle.PosX, cSalle.PosY, table.x, table.y });
                                restaurant.GetCarre(table.Carre).GetRang(table.Rang).GetTable(table.Numero).Groupe.Bouteille = nb;
                            }
                        }
                        
                    }
                }

            }
        }

        static private void RunChef()//Fini
        {
            LogController.Instance.Debug("Start Thread on Id: " + Thread.CurrentThread.ManagedThreadId);

            while (true)
            {
                var chefCuistos = personnels.Where(x => x.Metier == (int)PersonnelEnums.Chef_Cuisto);

                foreach (var cCuisto in chefCuistos)
                {
                    //On vérifie si le plat n'existe pas déjà
                    if(cCuisto.Plats.Count != 0)
                    {
                        if((restaurant.VitrineChauffante.Plats.Count != 0)&&(restaurant.VitrineChauffante.GetPlat(cCuisto.Plats[0].Nom) != null))//SI ca existe ici
                        {
                            Console.WriteLine("Le chef vas prendre le plat");
                            cCuisto.Call("Move", new object[4] { cCuisto.PosX, cCuisto.PosY, 13, 2 });//On vas a la vitrine
                            Thread.Sleep(2000);
                            Plat plat = restaurant.VitrineChauffante.PrendrePlat(cCuisto.Plats[0].Nom);//On prend le plat
                            cCuisto.Plats.RemoveAt(0);
                            Console.WriteLine("Le chef vas apporter le plat");
                            cCuisto.Call("Move", new object[4] { cCuisto.PosX, cCuisto.PosY, 12, 6 });//On le met sur le conmptoir en le modifiant
                            Thread.Sleep(2000);
                            restaurant.Comptoir.AddPlat(plat);

                        }
                        else if ((restaurant.Frigo.Plats.Count != 0)&&(restaurant.Frigo.GetPlat(cCuisto.Plats[0].Nom) != null))//Si ca existe ici
                        {
                            Console.WriteLine("Le chef vas prendre le plat");
                            cCuisto.Call("Move", new object[4] { cCuisto.PosX, cCuisto.PosY, 14, 2 });//On vas au frigo
                            Thread.Sleep(2000);
                            Plat plat = restaurant.Frigo.prendrePlat(cCuisto.Plats[0].Nom);//On prend le plat
                            cCuisto.Plats.RemoveAt(0);
                            Console.WriteLine("Le chef vas apporter le plat");
                            cCuisto.Call("Move", new object[4] { cCuisto.PosX, cCuisto.PosY, 12, 6 });//On le met sur le conmptoir en le modifiant
                            Thread.Sleep(2000);
                            restaurant.Comptoir.AddPlat(plat);
                        }
                        else//Si le plat n'existe pas en délègue
                        {
                            
                            var chefParties = personnels.Where(x => x.Metier == (int)PersonnelEnums.Chef_Partie).ToList<Personnel>();
                            if (chefParties[0].Plats.Count >= chefParties[1].Plats.Count)//On distribue equitablement les plats
                            {
                                Console.WriteLine("Le chef délègue au chef 2");
                                chefParties[1].Plats.Add(cCuisto.Plats[0]);
                                cCuisto.Plats.RemoveAt(0);
                            }
                            else
                            {
                                Console.WriteLine("Le chef délègue au chef 1");
                                chefParties[0].Plats.Add(cCuisto.Plats[0]);
                                cCuisto.Plats.RemoveAt(0);
                            }
                        }
                    }

                }

            }
        }

        static public void RunChefPlat()//Fini
        {
            LogController.Instance.Debug("Start Thread on Id: " + Thread.CurrentThread.ManagedThreadId);

            while (true)
            {
                var chefPlats = personnels.Where(x => x.Metier == (int)PersonnelEnums.Chef_Partie);

                foreach (var cPlats in chefPlats)
                {
                    //Check si le plat existe
                    //On vérifie si le plat n'existe pas déjà
                    if (cPlats.Plats.Count != 0)
                    {
                        if ((restaurant.VitrineChauffante.Plats.Count != 0) && (restaurant.VitrineChauffante.GetPlat(cPlats.Plats[0].Nom) != null))//SI ca existe ici
                        {
                            Console.WriteLine("Le chef vas prendre le plat");
                            cPlats.Call("Move", new object[4] { cPlats.PosX, cPlats.PosY, 13, 2 });//On vas a la vitrine
                            Thread.Sleep(2000);
                            Plat plat = restaurant.VitrineChauffante.PrendrePlat(cPlats.Plats[0].Nom);//On prend le plat
                            cPlats.Plats.RemoveAt(0);
                            Console.WriteLine("Le chef vas apporter le plat");
                            cPlats.Call("Move", new object[4] { cPlats.PosX, cPlats.PosY, 12, 6 });//On le met sur le conmptoir en le modifiant
                            Thread.Sleep(2000);
                            restaurant.Comptoir.AddPlat(plat);

                        }
                        else if ((restaurant.Frigo.Plats.Count != 0) && (restaurant.Frigo.GetPlat(cPlats.Plats[0].Nom) != null))//Si ca existe ici
                        {
                            Console.WriteLine("Le chef vas prendre le plat");
                            cPlats.Call("Move", new object[4] { cPlats.PosX, cPlats.PosY, 14, 2 });//On vas au frigo
                            Thread.Sleep(2000);
                            Plat plat = restaurant.Frigo.prendrePlat(cPlats.Plats[0].Nom);//On prend le plat
                            cPlats.Plats.RemoveAt(0);
                            Console.WriteLine("Le chef vas apporter le plat");
                            cPlats.Call("Move", new object[4] { cPlats.PosX, cPlats.PosY, 12, 6 });//On le met sur le conmptoir en le modifiant
                            Thread.Sleep(2000);
                            restaurant.Comptoir.AddPlat(plat);
                        }
                        else //Si le plat n'existe pas en délègue
                        {

                            var commisCuisine = personnels.Where(x => x.Metier == (int)PersonnelEnums.Commis_Cuisine).ToList<Personnel>();
                            if ((commisCuisine[0].Plats.Count >= commisCuisine[1].Plats.Count)&&(commisCuisine[1].Plats.Count < 3))//On distribue equitablement les plats
                            {
                                Console.WriteLine("Le chef délègue au commis 2");
                                commisCuisine[1].Plats.Add(cPlats.Plats[0]);
                                cPlats.Plats.RemoveAt(0);
                            }
                            else if((commisCuisine[1].Plats.Count >= commisCuisine[0].Plats.Count) && (commisCuisine[0].Plats.Count < 3))//On distribue les plats
                            {
                                Console.WriteLine("Le chef délègue au commis 1");
                                commisCuisine[0].Plats.Add(cPlats.Plats[0]);
                                cPlats.Plats.RemoveAt(0);
                            }
                            else//Sinon on cuisine
                            {
                                //Get recette
                                DatabaseController.Instance.Initialize("10.176.50.249", "chef", "password", "resto");
                                List<Etape> strss = DatabaseController.Instance.GetRecette(cPlats.Plats[0].Nom);
                                int nbPlat = 0;
                                foreach(Etape str in strss)//On traite chaque êtape
                                {
                                    if (str.Action == Etape.ActionEnum.Prendre)
                                    {
                                        nbPlat = str.Part;
                                        Console.WriteLine("Je prend");
                                        cPlats.Call("Move", new object[4] { cPlats.PosX, cPlats.PosY, 13, 2 });//On vas au frigo prendre l'aliment
                                        Thread.Sleep(5000);
                                    }
                                    else if (str.Action == Etape.ActionEnum.Preparer)
                                    {
                                        Console.WriteLine("Je prépare pendant : " + str.Temps + " secondes");
                                        cPlats.Call("Move", new object[4] { cPlats.PosX, cPlats.PosY, 5, 6 });//On vas au plan de travail préparer
                                        Thread.Sleep(str.Temps * 10);
                                        restaurant.Evier.Ustensiles.Add(new Ustensile(Ustensile.TYPE.COUTEAUCUISINE));
                                    }
                                    else if (str.Action == Etape.ActionEnum.Cuire)
                                    {
                                        Console.WriteLine("Je cuit pendant " + str.Temps + " secondes");
                                        cPlats.Call("Move", new object[4] { cPlats.PosX, cPlats.PosY, 8, 2 });//On vas au plaque
                                        Thread.Sleep(str.Temps * 10);
                                        restaurant.Evier.Ustensiles.Add(new Ustensile(Ustensile.TYPE.CASSEROLE));
                                    }
                                    else if (str.Action == Etape.ActionEnum.Cuire_Four)
                                    {
                                        Console.WriteLine("Je cuit au four pendant " + str.Temps + " secondes");
                                        cPlats.Call("Move", new object[4] { cPlats.PosX, cPlats.PosY, 5, 2 });//On vas au four
                                        Thread.Sleep(str.Temps * 10);
                                        restaurant.Evier.Ustensiles.Add(new Ustensile(Ustensile.TYPE.CASSEROLE));
                                    }
                                }
                                Console.WriteLine("Le commis aporte le plat");

                                cPlats.Call("Move", new object[4] { cPlats.PosX, cPlats.PosY, 12, 6 });//On le met sur le conmptoir en le modifiant//On le met dans le comptoir et on met la suite dans la vitrine
                                Thread.Sleep(2000);
                                restaurant.Comptoir.AddPlat(cPlats.Plats[0]);
                                for (int i = 0; i < nbPlat - 1; i++)
                                {
                                    restaurant.VitrineChauffante.AddPlat(cPlats.Plats[0]);
                                }
                                cPlats.Plats.RemoveAt(0);//On supprime le plat de la liste a faire

                            }
                            
                        }

                    }  
                }

            }
        }

        static public void RunCommisCuisine()//Fini
        {
            LogController.Instance.Debug("Start Thread on Id: " + Thread.CurrentThread.ManagedThreadId);

            while (true)
            {
                var commisCuisine = personnels.Where(x => x.Metier == (int)PersonnelEnums.Commis_Cuisine);

                foreach (var cCuisine in commisCuisine)
                {
                    if(cCuisine.Plats.Count != 0)
                    {
                        //Get recette
                        DatabaseController.Instance.Initialize("10.176.50.249", "chef", "password", "resto");
                        List<Etape> strss = DatabaseController.Instance.GetRecette(cCuisine.Plats[0].Nom);
                        DatabaseController.Instance.UpdateStock(cCuisine.Plats[0].Nom);//Update du stock
                        int nbPlat = 0;
                        foreach (Etape str in strss)//On traite chaque êtape
                        {
                            if (str.Action == Etape.ActionEnum.Prendre)
                            {
                                nbPlat = str.Part;
                                Console.WriteLine("Je prend");
                                cCuisine.Call("Move", new object[4] { cCuisine.PosX, cCuisine.PosY, 13, 2 });//On vas au frigo prendre l'aliment
                                Thread.Sleep(5000);
                            }
                            else if(str.Action == Etape.ActionEnum.Preparer)
                            {
                                Console.WriteLine("Je prépare pendant : " + str.Temps + " secondes");
                                cCuisine.Call("Move", new object[4] { cCuisine.PosX, cCuisine.PosY, 5, 6 });//On vas au plan de travail préparer
                                Thread.Sleep(str.Temps * 10);
                                restaurant.Evier.Ustensiles.Add(new Ustensile(Ustensile.TYPE.COUTEAUCUISINE));
                            }
                            else if (str.Action == Etape.ActionEnum.Cuire)
                            {
                                Console.WriteLine("Je cuit pendant " + str.Temps + " secondes");
                                cCuisine.Call("Move", new object[4] { cCuisine.PosX, cCuisine.PosY, 8, 2 });//On vas au plaque
                                Thread.Sleep(str.Temps * 10);
                                restaurant.Evier.Ustensiles.Add(new Ustensile(Ustensile.TYPE.CASSEROLE));
                            }
                            else if (str.Action == Etape.ActionEnum.Cuire_Four)
                            {
                                Console.WriteLine("Je cuit au four pendant " + str.Temps + " secondes");
                                cCuisine.Call("Move", new object[4] { cCuisine.PosX, cCuisine.PosY, 5, 2 });//On vas au four
                                Thread.Sleep(str.Temps * 10);
                                restaurant.Evier.Ustensiles.Add(new Ustensile(Ustensile.TYPE.CASSEROLE));
                            }
                        }
                        Console.WriteLine("Le commis aporte le plat");
                        
                        cCuisine.Call("Move", new object[4] { cCuisine.PosX, cCuisine.PosY, 12, 6 });//On le met sur le conmptoir en le modifiant//On le met dans le comptoir et on met la suite dans la vitrine
                        Thread.Sleep(2000);
                        restaurant.Comptoir.AddPlat(cCuisine.Plats[0]);
                        for(int i = 0; i < nbPlat - 1; i++)
                        {
                            restaurant.VitrineChauffante.AddPlat(cCuisine.Plats[0]);
                        }
                        cCuisine.Plats.RemoveAt(0);//On supprime le plat de la liste a faire
                    }
                }

            }
        }

        static private void RunPlongeur()//Fini
        {
            LogController.Instance.Debug("Start Thread on Id: " + Thread.CurrentThread.ManagedThreadId);

            while (true)
            {
                var plongeurs = personnels.Where(x => x.Metier == (int)PersonnelEnums.Plongeur);

                foreach (var plongeur in plongeurs)
                {
                    restaurant.Evier.laverUstensible();
                }

            }
        }

        private static void SpawnNpc()
        {
            LogController.Instance.Info("Génération des NPCs");
            /*DatabaseController.Instance.Initialize("10.176.50.249", "chef", "password", "resto");
            personnels = DatabaseController.Instance.GetPersonnels();*/

            Vue.InitVue(personnels);
        }
    }
}