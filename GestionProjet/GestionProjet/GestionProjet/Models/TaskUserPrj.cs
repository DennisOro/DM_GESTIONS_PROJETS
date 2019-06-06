using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Web.Mvc;

namespace GestionProjet.Models
{
    public class TaskUserPrj
    {
        public int IdTask { get; set; }
        public int ProjectId { get; set; }
        public string Description { get; set; }
        public string NomProjet { get; set; }
        public int nbHeuresEstime { get; set; }
        public int nbHeuresTravaillee { get; set; }
        public string Status { get; set; }
        public string Matricule { get; set; }
        public string Login { get; set; }
        //public int idStatus { get; set; }
         
        [DisplayName("Taches")]
        public String[] SelectedTaskIds { get; set; } 
        public IEnumerable<SelectListItem> TaskList { get; set; }

        public IEnumerable<SelectListItem> ProjectsList { get; set; }

        [DisplayName("Employes")]
        public String[] SelectedEmployesId{ get; set; }
        public IEnumerable<SelectListItem> EmployesList { get; set; }

        public TaskUserPrj()
        {
            ProjectsList = fillOutProjectsList();
            TaskList = fillOutTaskList();
            EmployesList = fillOutEmployeList();

        }

        public IEnumerable<SelectListItem> fillOutProjectsList()
        {
            var projectsList = new List<SelectListItem>();
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                    conn.Open();

                    string query = @"select idProjet from [INF6150].[dbo].[Project]";

                    SqlCommand command = new SqlCommand(query, conn);

                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            int value = reader[0] == null ? 0 : Convert.ToInt32(reader[0]);
                            projectsList.Add(new SelectListItem
                            {
                                Value = value.ToString(),
                                Text = value.ToString()
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
            return projectsList;
        }


        public IEnumerable<SelectListItem> fillOutTaskList()
        {
            var TaskList = new List<SelectListItem>();
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                    conn.Open();

                    string query = @"select description from [INF6150].[dbo].[Task]";

                    SqlCommand command = new SqlCommand(query, conn);

                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            int value = reader[0] == null ? 0 : Convert.ToInt32(reader[0]);
                            TaskList.Add(new SelectListItem
                            {
                                Value = value.ToString(),
                                Text = value.ToString()
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
            return TaskList;
        }

        public IEnumerable<SelectListItem> fillOutEmployeList()
        {
            var TaskList = new List<SelectListItem>();
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                    conn.Open();

                    string query = @"select matricule from [INF6150].[dbo].[User]";

                    SqlCommand command = new SqlCommand(query, conn);

                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            int value = reader[0] == null ? 0 : Convert.ToInt32(reader[0]);
                            TaskList.Add(new SelectListItem
                            {
                                Value = value.ToString(),
                                Text = value.ToString()
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
            return TaskList;
        }






        public List<TaskUserPrj> getTaskUserPrj(string login)
        {
            List<TaskUserPrj> TasksList = new List<TaskUserPrj>();
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                    conn.Open();

                    string query = @"select * from qTaskUserPrj where login = '" + login + "'";

                    SqlCommand command = new SqlCommand(query, conn);

                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            TasksList.Add(new TaskUserPrj()
                            {
                                IdTask = Convert.ToInt32(reader[0]),
                                Description = reader[1] == null ? "" : reader[1].ToString().Trim(),
                                NomProjet = reader[2].ToString().Trim(),
                                nbHeuresEstime = reader[3] == null ? 0 : Convert.ToInt32(reader[3]),
                                nbHeuresTravaillee = reader[4] == null ? 0 : Convert.ToInt32(reader[4]),
                                Status = reader[5].ToString().Trim(),
                                Matricule = reader[6].ToString().Trim(),
                                Login = reader[7].ToString().Trim(),
                                //idStatus = Convert.ToInt32(reader[5])
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

            return TasksList;

        }


        public void getTaskUserPrjById(int idTask, string login)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                    conn.Open();

                    string query = @"select * from qTaskUserPrj where idTache = "+idTask.ToString()+" and login = '" + login + "'";

                    SqlCommand command = new SqlCommand(query, conn);

                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        if (reader.Read())
                        {
                            IdTask = Convert.ToInt32(reader[0]);
                            Description = reader[1] == null ? "" : reader[1].ToString().Trim();
                            NomProjet = reader[2].ToString().Trim();
                            nbHeuresEstime = reader[3] == null ? 0 : Convert.ToInt32(reader[3]);
                            nbHeuresTravaillee = reader[4] == null ? 0 : Convert.ToInt32(reader[4]);
                            Status = reader[5].ToString().Trim();
                            Matricule = reader[6].ToString().Trim();
                            Login = reader[7].ToString().Trim();
                            //idStatus = Convert.ToInt32(reader[5]);
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

        }


        public void UpdateHrsTask(string login, int idtask, int heures, int status)
        {
            string query;
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                    conn.Open();
                    query = @"update TaskUser set nbrHeuresTravaillees = nbrHeuresTravaillees + @hrs " +
                        " from TaskUser as t " +
                        " join Login as l on t.matricule = l.matricule " +
                        "where idTache = @idtask and l.login = @login";

                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@hrs", heures);
                    command.Parameters.AddWithValue("@etat", status);
                    command.Parameters.AddWithValue("@idtask", idtask);
                    command.Parameters.AddWithValue("@login", login);
                    command.ExecuteNonQuery();

                    query = @"update Task set idEtat = @etat " +
                        "where idTache = @idtask";

                    command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@etat", status);
                    command.Parameters.AddWithValue("@idtask", idtask);
                    command.ExecuteNonQuery();

                    conn.Close();

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}