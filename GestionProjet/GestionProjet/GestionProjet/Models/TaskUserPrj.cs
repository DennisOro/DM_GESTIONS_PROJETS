using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace GestionProjet.Models
{
    public class TaskUserPrj
    {
        public int IdTask { get; set; }
        public string Description { get; set; }
        public string NomProjet { get; set; }
        public int nbHeures { get; set; }
        public string Status { get; set; }
        public string Matricule { get; set; }
        public string Login { get; set; }

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
                                nbHeures = reader[3] == null ? 0 : Convert.ToInt32(reader[3]),
                                Status = reader[4].ToString().Trim(),
                                Matricule = reader[5].ToString().Trim(),
                                Login = reader[6].ToString().Trim()
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