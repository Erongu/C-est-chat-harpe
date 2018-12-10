using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Model
{
    class BDD
    {

        public string BddCheckStock(int plat)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Data Source=tcp:10.176.50.249;Initial Catalog=resto;User ID=chef;Password=password";
                conn.Open();

                string request = String.Format("EXEC check_stock {0}", plat);
                SqlCommand command = new SqlCommand(request, conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // while there is another record present
                    while (reader.Read())
                    {
                        string platExiste = (String.Format("{0}", reader[0]));
                    }
                }
                conn.Close();
                return platExiste;
            }
            
        }

        public void UpdateStock(int plat)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Data Source=tcp:10.176.50.249;Initial Catalog=resto;User ID=chef;Password=password";

                SqlCommand command = new SqlCommand("update_stock", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@plat", plat));
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
        }

        void Livraison()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Data Source=tcp:10.176.50.249;Initial Catalog=resto;User ID=chef;Password=password";

                SqlCommand command = new SqlCommand("livraison", conn);
                command.CommandType = CommandType.StoredProcedure;
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
        }

    }
}
