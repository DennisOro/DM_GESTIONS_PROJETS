using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace GestionProjet.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Nom d'utilisateur est obligatoire")]
        public string UserID { get; set; }

        [Required(ErrorMessage = "Mot de passe est obligatoire")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool AuthentificationValide { get; set; }

        public string Role { get; set; }

        public string Message { get; set; }

        public bool testLogin(string userID, string password)
        {
            userID = userID == null ? "" : userID.Trim();
            password = password == null ? "" : password.Trim();

            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                    conn.Open();

                    string query = @"select * from Login";

                    SqlCommand command = new SqlCommand(query, conn);

                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            string storedUserID = reader[0] == null ? "" : reader[0].ToString().Trim();
                            string storedPassw = reader[1] == null ? "" : reader[1].ToString().Trim();

                            if (storedUserID == userID && storedPassw == password)
                            {
                                return true;
                            }
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
                Console.WriteLine("BD: "+ex.ToString()+" "+ex.Message);
            }
            return false;
        }

        public string getUserMatricule(string login, string passw)
        {
            string matricule = "";
            UserID = login; Password = passw;
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                    conn.Open();

                    string query = @"select matricule from Login where login = '" + login + "' and password = '" + passw +"'";

                    SqlCommand command = new SqlCommand(query, conn);

                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        if (reader.Read())
                        {
                            matricule = reader[0] == null ? "" : reader[0].ToString().Trim();
                            AuthentificationValide = true;
                            Message = "Connexion réussi";
                        }
                        else
                        {
                            AuthentificationValide = false;
                            Message = "Utilisateur ou mot de passe invalide";
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("BD: " + ex.ToString() + " " + ex.Message);
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
                Console.WriteLine("BD: " + ex.ToString() + " " + ex.Message);
            }

            return matricule;
        }

        public string testUserRole(string matricule)
        {
            string query = @"select role from [User] where matricule = '" + matricule + "'";

            string role = "";

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
                            role = reader[0] == null ? "" : reader[0].ToString().Trim();
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

            return role;
        }
    }

}