﻿using Controller;
using Controller.Strategy;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Model.Cuisine;
using System.Threading.Tasks;

namespace Controller
{
    public class DatabaseController
    {
        private static DatabaseController m_instance = null;

        public static DatabaseController Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new DatabaseController();
                return m_instance;
            }
        }

        public string Host
        {
            get;
            private set;
        }

        public string UserId
        {
            get;
            private set;
        }

        public string Password
        {
            get;
            private set;
        }

        public string Database
        {
            get;
            private set;
        }

        private string m_connectionString;

        public string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(m_connectionString))
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
                    {
                        DataSource = Host,
                        UserID = UserId,
                        Password = Password,
                        InitialCatalog = Database,
                        ConnectRetryCount = 0,
                        ConnectTimeout = 2
                    };

                    m_connectionString = builder.ConnectionString;
                }

                return m_connectionString;
            }
        }

        public DatabaseController()
        {

        }

        public void Initialize(string host, string userId, string password, string database)
        {
            Host = host;
            UserId = userId;
            Password = password;
            Database = database;

            LogController.Instance.Info("Ouverture de la base de données");
        }

        public List<Personnel> GetPersonnels()
        {
            try
            {
                var results = new List<Personnel>();
                var sqlConnection = new SqlConnection(ConnectionString);

                sqlConnection.Open();

                var command = sqlConnection.CreateCommand(); //Création de la commande
                command.CommandText = "SELECT * FROM personnel";

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var objet = new Dictionary<string, object>
                    {
                        { "id", reader[0] },
                        { "prenom", reader[1] },
                        { "nom", reader[2] },
                        { "metier", reader[4] },
                        { "posx", reader[5] },
                        { "posy", reader[6] }
                    };

                    Personnel personnel = new Factory().Create<Personnel>(objet);
                    results.Add(personnel);
                }

                reader.Close();
                sqlConnection.Dispose();

                return results;
            }
            catch
            {
                LogController.Instance.Error("Database connection timeout");
                return new List<Personnel>();
            }
        }



        public List<Etape> GetRecette(int plat)
        {
            try
            {
                var results = new List<Etape>();
                var sqlConnection = new SqlConnection(ConnectionString);

                sqlConnection.Open();

                var command = sqlConnection.CreateCommand(); //Création de la commande
                command.CommandText = "SELECT  nombre,action,temps,etape,id_plat,id_ingredient,part FROM recette inner join plat on recette.id_plat = plat.id  WHERE id_plat = @plat order by etape ";//(plat) VALUES (@plat)
                command.Parameters.AddWithValue("@plat", plat);
                command.ExecuteNonQuery();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    results.Add(new Etape(int.Parse(reader[1].ToString()),int.Parse(reader[2].ToString()),int.Parse(reader[5].ToString()),int.Parse(reader[6].ToString())));
                }

                reader.Close();
                sqlConnection.Dispose();

                return results;
            }
            catch
            {
                LogController.Instance.Error("Database connection timeout");
                return new List<Etape>();
            }
        }




        public void UpdateStock(int plat)
        {
            try
            {
                var sqlConnection = new SqlConnection(ConnectionString);

                SqlCommand command = new SqlCommand("update_stock", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@plat", plat));

                sqlConnection.Open();
                command.ExecuteNonQuery();

            }
            catch
            {
                LogController.Instance.Error("Database connection timeout");
            }
        }


        public List<int> CheckStock(int plat)
        {
            List<int> platExiste = new List<int>();

            try
            {
                var sqlConnection = new SqlConnection(ConnectionString);

                SqlCommand command = new SqlCommand("check_stock", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@plat", plat));
                sqlConnection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // while there is another record present

                    while (reader.Read())
                    {
                        platExiste.Add((int)reader[0]);
                    }
                }
                sqlConnection.Dispose();
            }
            catch
            {
                LogController.Instance.Error("Database connection timeout");
            }
            return platExiste;
        }

        public void Livraison()
        {
            try
            {
                var sqlConnection = new SqlConnection(ConnectionString);

                SqlCommand command = new SqlCommand("livraison", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
            catch
            {
                LogController.Instance.Error("Database connection timeout");
            }
        }

        public int GetEntree()
        {
            int platid = 0;

            try
            {
                var sqlConnection = new SqlConnection(ConnectionString);

                SqlCommand command = new SqlCommand("choix_entree", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;     
                sqlConnection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        platid = int.Parse(reader[0].ToString());
                    }
                }
                sqlConnection.Dispose();
            }
            catch
            {
                LogController.Instance.Error("Database connection timeout");
            }
            return platid;
        }

        public int Getplat()
        {
            int platid = 0;

            try
            {
                var sqlConnection = new SqlConnection(ConnectionString);

                SqlCommand command = new SqlCommand("choix_plat", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        platid = int.Parse(reader[0].ToString());
                    }
                }
                sqlConnection.Dispose();
            }
            catch
            {
                LogController.Instance.Error("Database connection timeout");
            }
            return platid;
        }


        public int GetDessert()
        {
            int platid = 0;

            try
            {
                var sqlConnection = new SqlConnection(ConnectionString);

                SqlCommand command = new SqlCommand("choix_dessert", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        platid = int.Parse(reader[0].ToString());
                    }
                }
                sqlConnection.Dispose();
            }
            catch
            {
                LogController.Instance.Error("Database connection timeout");
            }
            return platid;
        }


    }   
}
