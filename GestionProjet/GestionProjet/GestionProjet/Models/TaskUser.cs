using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace GestionProjet.Models
{
    public class TaskUser
    {
        public int IdTask { get; set; }
        public string Matricule { get; set; }
        public string Tnom { get; set; }

        public List<TaskUser> getTaskUser(int idTask)
        {
            List<TaskUser> TasksList = new List<TaskUser>();
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                    conn.Open();

                    string query = @"select t.idTache,l.matricule,u.prenom+' '+u.nom as Tnom from Login as l join [INF6150].[dbo].[User] as u on u.matricule=l.matricule join TaskUser as t on t.matricule=u.matricule where t.idTache=" + idTask.ToString();

                    SqlCommand command = new SqlCommand(query, conn);

                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            TasksList.Add(new TaskUser()
                            {
                                IdTask = Convert.ToInt32(reader[0]),
                                Matricule = reader[1].ToString().Trim(),
                                Tnom = reader[2].ToString().Trim()
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

        public bool deleteTaskUser(int idTask, string matricule)
        {

                string deleteQuery = @"delete from [INF6150].[dbo].[TaskUser] where idTache = " + idTask + " and matricule='"+matricule+"'";

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
                return false;
                }
            return true;
        }

    }
}