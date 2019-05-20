using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace GestionProjet.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        

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
                            ProjectsList.Add(new Project() { ProjectId = Convert.ToInt32(reader[0]), ProjectName = reader[1].ToString() });
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
                            ProjectName = reader[1] == null ? "" : reader[1].ToString();
                            StartDate = reader[4] == null ? "" : reader[4].ToString();
                            EndDate = reader[5] == null ? "" : reader[5].ToString();
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