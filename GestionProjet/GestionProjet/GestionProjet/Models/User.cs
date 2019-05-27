﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Mvc;

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
                            matricule = reader[0] == null ? "" : reader[0].ToString().Trim();
                            FirstName = reader[1] == null ? "" : reader[1].ToString().Trim();
                            LastName = reader[2] == null ? "" : reader[2].ToString().Trim();
                            HourlyRate = reader[3] == null ? 0 : Convert.ToInt32(reader[3]);
                            Role = reader[4] == null ? "" : reader[4].ToString().Trim();
                        }else
                        {
                            matricule = "" ;
                            FirstName = "" ;
                            LastName = "" ;
                            HourlyRate = 0;
                            Role = "" ;
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

            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                    conn.Open();

                    string query = @"select role from [User]";

                    SqlCommand command = new SqlCommand(query, conn);

                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            string value = reader[0] == null ? "" : reader[0].ToString();
                            rolesList.Add(new SelectListItem
                            {
                                Value = value,
                                Text = value
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
            catch (Exception ex) //(IEnumerable<T>)
            {
                Console.WriteLine(ex.ToString());
            }
            return rolesList;
        }
/*
        public User updateUser()
        {
            try
            {
                //string projectName = project.ProjectName == null ? "" : project.ProjectName.Trim();
                //string updateQuery = @"UPDATE [INF6150].[dbo].[Project]  SET nomProjet = '" + projectName + "', "
                //                                                        + "dateDebut =  '" + project.StartDate + "', "
                //                                                        + "dateFin =  '" + project.EndDate + "' "
                //                                                        + "WHERE idProjet = " + project.ProjectId;


                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                    conn.Open();

                    //SqlCommand command = new SqlCommand(updateQuery, conn);

                    command.ExecuteNonQuery();

                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return project;
        }
*/
    }
}