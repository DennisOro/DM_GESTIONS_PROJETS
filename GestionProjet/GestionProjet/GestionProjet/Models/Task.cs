using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace GestionProjet.Models
{
    public class Task
    {
        public int IdTask { get; set; }
        public string Description { get; set; }
        public int NBAssignedUsers { get; set; }
        public string Status { get; set; }

        public List<Task> getTasksFromDatabase()
        {
            List<Task> TasksList = new List<Task>();
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                    conn.Open();

                    string query = @"select * from [Task]";

                    SqlCommand command = new SqlCommand(query, conn);

                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            TasksList.Add(new Task()
                            {
                                Description = reader[5] == null ? "" : reader[5].ToString(),
                                Status = reader[6] == null ? "" : reader[6].ToString()
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

    }
}