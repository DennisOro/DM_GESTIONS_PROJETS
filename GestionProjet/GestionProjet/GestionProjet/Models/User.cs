using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace GestionProjet.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IDUser { get; set; }
        public int HourlyRate { get; set; }
        public int nbrUsers { get; set; }
        public string Role { get; set; }

        public List<User> getUsersFromDatabase()
        {
            List<User> UsersList = new List<User>();
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                    conn.Open();

                    string query = @"select * from [User]";

                    SqlCommand command = new SqlCommand(query, conn);

                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            UsersList.Add(new User() {
                                IDUser = reader[0] == null ? "" : reader[0].ToString(),
                                FirstName = reader[1] == null ? "" : reader[1].ToString(),
                                LastName = reader[2] == null ? "" : reader[2].ToString(),
                                HourlyRate = reader[3] == null ? 0 : Convert.ToInt32(reader[3]),
                                nbrUsers = reader[4] == null ? 0 : Convert.ToInt32(reader[4]),
                                Role = reader[5] == null ? "" : reader[5].ToString()
                            });
                        }
                    }
                    finally
                    {
                        reader.Close();
                    }

                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return UsersList;

        }
    }
}