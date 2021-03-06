﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace GestionProjet.Models
{
    public class User
    {
        [Required(ErrorMessage = "Prenom est obligatoire")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Nom est obligatoire")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Matricule est obligatoire")]
        public string matricule { get; set; }
        public double HourlyRate { get; set; }
        public int nbrUsers { get; set; }
        public string Role { get; set; }
        public bool NewUser { get; set; }
        public Login Login { get; set; }
        public string telephone { get; set; }
        public string codePostal { get; set; }

        public IEnumerable<SelectListItem> RolesList { get; set; }

        public User()
        {
            RolesList = fillOutRolesList();
        }

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
                                matricule = reader[0] == null ? "" : reader[0].ToString().Trim(),
                                FirstName = reader[1] == null ? "" : reader[1].ToString().Trim(),
                                LastName = reader[2] == null ? "" : reader[2].ToString().Trim(),
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
            lastName = lastName == null ? "" : lastName.Trim();
            string query = @"select * from [User] where prenom = '" + firstName + "' and nom = '" + lastName + "'";
            return getUserInfo(query);
        }

        public User getUserInfoByLogin(string login)
        {
            login = login == null ? "" : login.Trim();
            string query = @"select u.* from[User] as u join [Login] as l on u.matricule = l.matricule where l.login = '" + login + "'";
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
                            matricule = reader[0] == null ? "" : reader[0].ToString().Trim();
                            FirstName = reader[1] == null ? "" : reader[1].ToString().Trim();
                            LastName = reader[2] == null ? "" : reader[2].ToString().Trim();
                            HourlyRate = reader[3] == null ? 0 : Convert.ToInt32(reader[3]);
                            Role = reader[4] == null ? "" : reader[4].ToString().Trim();
                            telephone = reader[5] == null ? "" : reader[5].ToString().Trim();
                            codePostal = reader[6] == null ? "" : reader[6].ToString().Trim();
                        }
                        else
                        {
                            matricule = "" ;
                            FirstName = "" ;
                            LastName = "" ;
                            HourlyRate = 0;
                            Role = "" ;
                            telephone = "";
                            codePostal = "";
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

        public IEnumerable<SelectListItem> fillOutRolesList()
        {
            var rolesList = new List<SelectListItem>();

            rolesList.Add(new SelectListItem
            {
                Value = "Gestionnaire",
                Text = "Gestionnaire"
            });
            rolesList.Add(new SelectListItem
            {
                Value = "Admin",
                Text = "Admin"
            });
            rolesList.Add(new SelectListItem
            {
                Value = "Utilisateur",
                Text = "Utilisateur"
            });
            
            return rolesList;
        }

        public bool updateUser(User user)
        {
            try
            {
                string matricule = user.matricule == null ? "" : user.matricule.Trim();
                string firstName = user.FirstName == null ? "" : user.FirstName.Trim();
                string lastName = user.LastName == null ? "" : user.LastName.Trim();
                string telephone = user.telephone == null ? "" : user.telephone.Trim();
                string codePostal = user.codePostal == null ? "" : user.codePostal.Trim();
                string role = user.Role == null ? "" : user.Role.Trim();
                string updateQuery = @"UPDATE [INF6150].[dbo].[User]  SET prenom = '" + firstName + "', "
                                                                        + "nom =  '" + lastName + "', "
                                                                        + "tauxHoraire =  " + user.HourlyRate + ", "
                                                                        + "role =  '" + role + "', "
                                                                        + "num_tel = '" + telephone + "',"
                                                                        + "code_postal = '" + codePostal + "'"
                                                                        + "WHERE matricule = '" + matricule + "'";


                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                    conn.Open();

                    SqlCommand command = new SqlCommand(updateQuery, conn);

                    command.ExecuteNonQuery();

                    conn.Close();
                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        public bool createUser(User user)
        {
            // test if matricule does not exist

            if (user != null)
            {
                string createQuery = @"INSERT INTO [INF6150].[dbo].[User] (matricule, prenom, nom, tauxHoraire, role, code_postal, num_tel)"
                                     + "VALUES ('" + user.matricule + "','" + user.FirstName + "','" + user.LastName + "', '" + user.HourlyRate + "', '" + user.Role + "', '" + user.codePostal + "', '" + user.telephone + "')";

                try
                {
                    using (SqlConnection conn = new SqlConnection())
                    {
                        conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                        conn.Open();

                        SqlCommand command = new SqlCommand(createQuery, conn);

                        command.ExecuteNonQuery();

                        conn.Close();

                        return true;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return false;
        }

        public bool matriculeExists(string matricule)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                    conn.Open();

                    string query = @"select matricule from [User] where matricule = '" + matricule + "'";

                    SqlCommand command = new SqlCommand(query, conn);

                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        if (reader.HasRows)
                            return true;
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
            return false;
        }

        public void setSelectedRole(ref User user)
        {
            string role = user == null || user.Role == null ? "" : user.Role.Trim();

            if(role != "")
            foreach(var elem in user.RolesList)
            {
                if(elem.Value == role)
                {
                    elem.Selected = true;
                }
            }
        }

        public bool deleteUser(string firstName, string lastName)
        {
            User newUser = getUserInfoByName(firstName, lastName);

            if (deleteUser(newUser))
                return true;
            else
                return false;
        }


        public bool deleteUser(User newUser)
        {
            string deleteQuery = @" delete from [INF6150].[dbo].[TaskUser] where matricule = '" + newUser.matricule + "';"
                                 + "delete from [INF6150].[dbo].[User] where matricule = '" + newUser.matricule + "';"
                                 +"delete from [INF6150].[dbo].[Login] where matricule = '" + newUser.matricule + "'";


            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                    conn.Open();

                    SqlCommand command = new SqlCommand(deleteQuery, conn);

                    command.ExecuteNonQuery();

                    conn.Close();

                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }
    }
}