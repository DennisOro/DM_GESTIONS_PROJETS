using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace GestionProjet.Models
{
    public class TaskUserDays
    {
        public string Jour { get; set; }
        public string Date { get; set; }
        public int NbHrs { get; set; }
        public int IdProjet { get; set; }
        public string NomProjet { get; set; }
        public int IdTask { get; set; }
        public string Description { get; set; }
        public double TauxHoraire{ get; set; }
        public string Login { get; set; }
        public string Matricule { get; set; }
        public string Tnom { get; set; }

        public List<TaskUserDays> getTaskUserHrs(string login, string date)
        {
            List<TaskUserDays> TasksList = new List<TaskUserDays>();
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                    conn.Open();

                    string query = @"select * from qTaskUserDays where login = '" + login + "' and date >= '"+date+"'";

                    SqlCommand command = new SqlCommand(query, conn);

                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            TasksList.Add(new TaskUserDays()
                            {
                                Jour = reader[0] == null ? "" : reader[0].ToString().Trim(),
                                Date = reader[1] == null ? "" : reader[1].ToString().Trim(),
                                NbHrs = Convert.ToInt32(reader[2]),
                                IdProjet = Convert.ToInt32(reader[3]),
                                NomProjet = reader[4].ToString().Trim(),
                                IdTask = Convert.ToInt32(reader[5]),
                                Description = reader[6] == null ? "" : reader[6].ToString().Trim(),
                                TauxHoraire = reader[7] == null ? 0 : Convert.ToDouble(reader[7]),
                                Login = reader[8].ToString().Trim(),
                                Matricule = reader[9].ToString().Trim(),
                                Tnom = reader[10].ToString().Trim()
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