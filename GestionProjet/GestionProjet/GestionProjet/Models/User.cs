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
        public string matricule { get; set; }
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
                                matricule = reader[0] == null ? "" : reader[0].ToString(),
                                FirstName = reader[1] == null ? "" : reader[1].ToString(),
                                LastName = reader[2] == null ? "" : reader[2].ToString(),
                                HourlyRate = reader[3] == null ? 0 : Convert.ToInt32(reader[3]),
                                Role = reader[4] == null ? "" : reader[4].ToString()
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

        public User getUserInfoByID(string userID)
        {
            string query = @"select * from [User] where matricule = '" + userID + "'";
            return getUserInfo(query);
        }

        public User getUserInfoByName(string firstName, string lastName)
        {
            firstName = firstName == null ? "" : firstName.Trim();
            string query = @"select * from [User] where prenom = '" + firstName + "' and 'nom = " + lastName + "'";
            return getUserInfo(query);
        }

        public User getUserInfo(string query)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                    conn.Open();

                    SqlCommand command = new SqlCommand(query, conn);

                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        if (reader.Read())
                        {
                            matricule = reader[0] == null ? "" : reader[0].ToString();
                            FirstName = reader[1] == null ? "" : reader[1].ToString();
                            LastName = reader[2] == null ? "" : reader[2].ToString();
                            HourlyRate = reader[3] == null ? 0 : Convert.ToInt32(reader[3]);
                            Role = reader[4] == null ? "" : reader[4].ToString();
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

            return this;
        }

        
    }
}