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
        public int nbHeuresTravaille { get; set; }
        public int nbHeuresEstime { get; set; }
        public string Status { get; set; }
        public int idProjet { get; set; }
        //public Project Project { get; set; }

        public List<Task> getTasksFromDatabase()
        {
            List<Task> TasksList = new List<Task>();
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                    conn.Open();

                    string query = @"select distinct t.idTache, t.description, tp.totHeuresTravaillees, tp.nbrHeuresEstime, e.descEtat, t.idProjet
                                    from [INF6150].[dbo].[Task] t
                                    join [INF6150].[dbo].[qTaskPrj] tp on t.idTache = tp.idTache and t.idProjet = tp.idProjet
                                    join [INF6150].[dbo].[Etat] e on t.idEtat = e.idEtat";

                    SqlCommand command = new SqlCommand(query, conn);

                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            TasksList.Add(new Task()
                            {
                                IdTask = reader[0] == null ? 0 : Convert.ToInt32(reader[0]),
                                Description = reader[1] == null ? "" : reader[1].ToString().Trim(),
                                nbHeuresTravaille = reader[2] == null ? 0 : Convert.ToInt32(reader[2]),
                                nbHeuresEstime = reader[3] == null ? 0 : Convert.ToInt32(reader[3]),
                                Status = reader[4] == null ? "" : reader[4].ToString().Trim(),
                                idProjet = reader[5] == null ? 0 : Convert.ToInt32(reader[5]),
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

        public Task getTaskInfo(string description, int idProjet)
        {
            string query = @"select distinct t.idTache, t.description, tp.totHeuresTravaillees, tp.nbrHeuresEstime, e.descEtat, t.idProjet
                                    from [INF6150].[dbo].[Task] t
                                    join [INF6150].[dbo].[qTaskPrj] tp on t.idTache = tp.idTache and t.idProjet = tp.idProjet
                                    join [INF6150].[dbo].[Etat] e on t.idEtat = e.idEtat 
                                    where t.description like '" + description + "%' and t.idProjet = " + idProjet;
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
                            IdTask = reader[0] == null ? 0 : Convert.ToInt32(reader[0]);
                            Description = reader[1] == null ? "" : reader[1].ToString().Trim();
                            nbHeuresTravaille = reader[2] == null ? 0 : Convert.ToInt32(reader[2]);
                            nbHeuresEstime = reader[3] == null ? 0 : Convert.ToInt32(reader[3]);
                            Status = reader[4] == null ? "" : reader[4].ToString().Trim();
                            idProjet = reader[5] == null ? 0 : Convert.ToInt32(reader[5]);
                        }
                        else
                        {
                            IdTask = 0;
                            Description = "";
                            nbHeuresTravaille = 0;
                            nbHeuresEstime = 0;
                            Status = "";
                            idProjet = 0;
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