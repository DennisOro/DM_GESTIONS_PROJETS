using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Mvc;



namespace GestionProjet.Models
{


    public class TaskAssign
    {
        public int IdTask { get; set; }
        public string Description { get; set; }
        public int nbHeuresTravaille { get; set; }
        public int nbHeuresEstime { get; set; }
        public int idStatus { get; set; }
        public string Status { get; set; }
        public int idProjet { get; set; }
        public bool NewTask { get; set; }

        public bool NewTask2 { get; set; }
        public int nbHeures { get; set; }
        public string Login { get; set; }
        public DateTime dateCreation { get; set; }
        //public string ClientName { get; set; }

        public List<TaskAssign> TasksList { get; set; }
        public List<TaskUser> TaskUserList { get; set; }



        public string utilisateur { get; set; }

        public IEnumerable<SelectListItem> StatusList { get; set; }
        public IEnumerable<SelectListItem> ProjectsList { get; set; }

        // employés pour la liste déroulante d'assignation des tâches
        public IEnumerable<SelectListItem> EmployeesList { get; set; }

        public TaskAssign()
        {
            StatusList = fillOutStatusesList();
            ProjectsList = fillOutProjectsList();
            EmployeesList = fillOutEmployeesList();
        }

        public List<TaskAssign> getAllTasksFromDatabase()
        {
            string query = @"select idTache, description, totHeuresTravaillees, nbrHeuresEstime, descEtat, idProjet, idEtat 
                                from [INF6150].[dbo].[qTaskPrj]";

            return getTasksFromDatabase(query);
        }

        // lister la tâches par login
        public List<TaskAssign> getAllTasksByUser(String Login)
        {
            string query = @"select t.idTache, t.matricule, t.nbrHeuresTravailles, t.dateCreation
                           FROM [INF6150].[dbo].[TaskUser] as t join Login as x on x.matricule=t.matricule
            where x.login = '" + Login + "'";

            return getTasksFromDatabase(query);
        }


        public List<TaskAssign> getAllTasksByLogin(String Login)
        {
            string query = @"select q.idTache, q.description, q.totHeuresTravaillees, q.nbrHeuresEstime, q.descEtat, q.idProjet, q.idEtat 
		                        from [INF6150].[dbo].[qTaskPrj] as q join TaskUser as k on k.idTache = q.idTache 
		                        join login as l on l.matricule=k.matricule 
		                      where l.login = '" + Login + "'";

            return getTasksFromDatabase(query);
        }

        public List<TaskAssign> getTasksListForProject(int idProject)
        {
            string query = @"select distinct t.idTache, t.description, tp.totHeuresTravaillees, tp.nbrHeuresEstime, e.descEtat, t.idProjet, t.idEtat
                                    from [INF6150].[dbo].[Task] t
                                    join [INF6150].[dbo].[qTaskPrj] tp on t.idTache = tp.idTache and t.idProjet = tp.idProjet
                                    join [INF6150].[dbo].[Etat] e on t.idEtat = e.idEtat
									where t.idProjet = " + idProject;

            return getTasksFromDatabase(query);
        }

        // pour assigner un une tâches à un user
        public void addTaskUser(TaskAssign task)
        {
            try
            {


                string addQuery = @"insert into [INF6150].[dbo].[TaskUser](idTache,matricule)"
                                    + "VALUES(" + task.IdTask + ", '" + task.utilisateur + "')";

                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                    conn.Open();

                    SqlCommand command = new SqlCommand(addQuery, conn);

                    command.ExecuteNonQuery();

                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }



        public List<TaskAssign> getTasksFromDatabase(string query)
        {
            List<TaskAssign> TasksList = new List<TaskAssign>();
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
                        while (reader.Read())
                        {
                            TasksList.Add(new TaskAssign()
                            {
                                IdTask = reader[0] == null ? 0 : Convert.ToInt32(reader[0]),
                                Description = reader[1] == null ? "" : reader[1].ToString().Trim(),
                                nbHeuresTravaille = reader[2] == null ? 0 : Convert.ToInt32(reader[2]),
                                nbHeuresEstime = reader[3] == null ? 0 : Convert.ToInt32(reader[3]),
                                Status = reader[4] == null ? "" : reader[4].ToString().Trim(),
                                idProjet = reader[5] == null ? 0 : Convert.ToInt32(reader[5]),
                                idStatus = reader[6] == null ? 0 : Convert.ToInt32(reader[6])
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

        public TaskAssign getTaskInfo(string description, int idProjet)
        {
            string query = @"select distinct t.idTache, t.description, tp.totHeuresTravaillees, tp.nbrHeuresEstime, e.descEtat, t.idProjet, t.idEtat
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
                            this.idProjet = idProjet;
                            idStatus = reader[6] == null ? 0 : Convert.ToInt32(reader[6]);
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

        public TaskAssign updateTask(TaskAssign task)
        {
            task.idStatus = getStatusID(task.Status);
            try
            {
                string description = task.Description == null ? "" : task.Description.ToString().Trim();
                //                string status = task.Status == null ? "" : task.Status.ToString().Trim();

                string updateQuery = @"update [INF6150].[dbo].[Task] set description = '" + description + "', "
                                                                            + "idProjet = " + task.idProjet + ", "
                                                                            + "idEtat = " + task.idStatus + ", "
                                                                            + "nbrHeuresEstime = " + task.nbHeuresEstime + " "
                                                                            + "where idTache = " + task.IdTask;

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
            return task;
        }

        public bool deleteTask(int idTask)
        {
            string deleteQuery = @"delete from [INF6150].[dbo].[TaskUser] where idTache = " + idTask + "; delete from [INF6150].[dbo].[Task] where idTache = " + idTask;

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

        public IEnumerable<SelectListItem> fillOutStatusesList()
        {
            var statusList = new List<SelectListItem>();
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                    conn.Open();

                    string query = @"select descEtat from [INF6150].[dbo].[Etat]";

                    SqlCommand command = new SqlCommand(query, conn);

                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            string value = reader[0] == null ? "" : reader[0].ToString().Trim();
                            statusList.Add(new SelectListItem
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return statusList;
        }

        public IEnumerable<SelectListItem> fillOutEmployeesList()
        {
            var EmployeesList = new List<SelectListItem>();
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                    conn.Open();

                    string query = @" select l.matricule,u.prenom+' '+u.nom as Tnom from Login as l join [INF6150].[dbo].[User] as u on u.matricule=l.matricule where u.role='Utilisateur'";

                    SqlCommand command = new SqlCommand(query, conn);

                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            string value = reader[0] == null ? "" : reader[0].ToString();
                            EmployeesList.Add(new SelectListItem
                            {
                                Value = value.ToString(),
                                Text = reader[1].ToString()
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
            return EmployeesList;
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

                    string query = @"select idProjet, nomProjet from [INF6150].[dbo].[Project]";

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
                                Text = reader[1].ToString()
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



        public TaskAssign createTask(TaskAssign task)
        {
            // test if task does not exist

            task.idStatus = getStatusID(task.Status);

            string createQuery = @"INSERT INTO [INF6150].[dbo].[Task] (idTache, description, idProjet, nbrHeuresEstime, idEtat) "
                                 + "VALUES (" + getNextTaskID() + ",'" + task.Description + "', " + task.idProjet + ", " + task.nbHeuresEstime + ", " + task.idStatus + ")";

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
            return task;
        }

        public int getNextTaskID()
        {
            string query = @"select top 1 idTache from [INF6150].[dbo].[Task] order by idTache desc";

            int nextIdTask = 0;

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
                            nextIdTask = reader[0] == null ? 0 : Convert.ToInt32(reader[0]);
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

            return nextIdTask + 1;
        }

        public int getStatusID(string statusDescr)
        {
            string query = @"select idEtat from [INF6150].[dbo].[Etat] where descEtat like '" + statusDescr + "%'";

            int idEtat = 0;
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
                            idEtat = reader[0] == null ? 0 : Convert.ToInt32(reader[0]);
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

            return idEtat;
        }







    }
}