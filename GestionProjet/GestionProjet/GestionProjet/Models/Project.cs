using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace GestionProjet.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ClientName { get; set; }
        public string StateDescription { get; set; }
        public int IdClient { get; set; }
        public int IdEtat { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public IEnumerable<SelectListItem> StatesList { get; set; }

        public List<Project> getProjectsFromDatabase()
        {
            List<Project> ProjectsList = new List<Project>();
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                    conn.Open();

                    string query = @"select * from Project";

                    SqlCommand command = new SqlCommand(query, conn);

                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            ProjectsList.Add(new Project() { ProjectId = Convert.ToInt32(reader[0]), ProjectName = reader[1].ToString().Trim() });
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

            return ProjectsList;

        }

        public Project getProjectInfo(int projectId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                    conn.Open();

                    string query = @"select * from Project where idProjet = '" + projectId + "'";

                    SqlCommand command = new SqlCommand(query, conn);

                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        if (reader.Read())
                        {
                            ProjectId = reader[0] == null ? 0 : Convert.ToInt32(reader[0]);
                            ProjectName = reader[1] == null ? "" : reader[1].ToString().Trim();
                            StartDate = reader[4] == null ? "" : reader[4].ToString().Trim();
                            EndDate = reader[5] == null ? "" : reader[5].ToString().Trim();
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

        public Project updateProject(Project project)
        {
            try
            {
                string projectName = project.ProjectName == null ? "" : project.ProjectName.Trim();
                string updateQuery = @"UPDATE [INF6150].[dbo].[Project]  SET nomProjet = '" + projectName + "', "
                                                                        + "dateDebut =  '" + project.StartDate + "', "
                                                                        + "dateFin =  '" + project.EndDate + "' "
                                                                        + "WHERE idProjet = " + project.ProjectId;

            
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                    conn.Open();

                    SqlCommand command = new SqlCommand(updateQuery, conn);

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

        public Project createProject(Project project)
        {
            int projectId = getNextProjectId();

            int clientId = project.ClientName == null ? 0 : getClientId(project.ClientName.Trim());

            int stateId = project.StateDescription == null ? 0 : getStateId(project.StateDescription.Trim());

            if (projectId > 0)
            {
                string createQuery = @"INSERT INTO [INF6150].[dbo].[Project] values (" + projectId + ",'" + project.ProjectName + "'," + clientId + ", " + stateId + ", '" + project.StartDate + "', '" + project.EndDate + "')";

                try
                {
                    using (SqlConnection conn = new SqlConnection())
                    {
                        conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                        conn.Open();

                        SqlCommand command = new SqlCommand(createQuery, conn);

                        command.ExecuteNonQuery();

                        conn.Close();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return project;
        }

        public int getNextProjectId()
        {
            int projectId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                    conn.Open();

                    string query = @"select top 1 idProjet from [INF6150].[dbo].[Project] order by idProjet desc";

                    SqlCommand command = new SqlCommand(query, conn);

                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        if (reader.Read())
                        {
                            projectId = reader[0] == null ? 0 : Convert.ToInt32(reader[0]);
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
                return 0;
            }
            return projectId + 1;
        }

        public int getClientId(string clientName)
        {
            int clientId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                    conn.Open();

                    string query = @"select idClient from [INF6150].[dbo].[Client] where nomClient = '" + clientName + "'";

                    SqlCommand command = new SqlCommand(query, conn);

                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        if (reader.Read())
                        {
                            clientId = reader[0] == null ? 0 : Convert.ToInt32(reader[0]);
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
                return 0;
            }
            return clientId;
        }


        public int getStateId(string stateDesc)
        {
            int stateId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                    conn.Open();

                    string query = @"select idEtat from [INF6150].[dbo].[Etat] where descEtat = '" + stateDesc + "'";

                    SqlCommand command = new SqlCommand(query, conn);

                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        if (reader.Read())
                        {
                            stateId = reader[0] == null ? 0 : Convert.ToInt32(reader[0]);
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
                return 0;
            }
            return stateId;
        }

        public bool deleteProject(int projectId)
        {
            List<int> tasksList = getIDTasksForProject(projectId);

            deleteTasksFromTaskUser(tasksList);

            deleteTasksRelatedToProject(projectId);

            string deleteQuery = @"delete from Project where idProjet = " + projectId;

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

        public List<int> getIDTasksForProject(int projectId)
        {
            List<int> idTasks = new List<int>();
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                    conn.Open();

                    string query = @"select * from [INF6150].[dbo].[Task] where idProjet =" + projectId;

                    SqlCommand command = new SqlCommand(query, conn);

                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            idTasks.Add(reader[0] == null ? 0 : Convert.ToInt32(reader[0]));
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
            return idTasks;
        }

        public void deleteTasksFromTaskUser(List<int> idTasks)
        {
            foreach(int idTask in idTasks)
            {
                string deleteQuery = @"delete from [INF6150].[dbo].[TaskUser] where idTache = " + idTask;

                try
                {
                    using (SqlConnection conn = new SqlConnection())
                    {
                        conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                        conn.Open();

                        SqlCommand command = new SqlCommand(deleteQuery, conn);

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

        public void deleteTasksRelatedToProject(int projectId)
        {
            string deleteQuery = @"delete  from [INF6150].[dbo].[Task] where idProjet = " + projectId;

            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                    conn.Open();

                    SqlCommand command = new SqlCommand(deleteQuery, conn);

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