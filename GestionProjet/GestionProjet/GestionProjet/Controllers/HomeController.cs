using GestionProjet.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SqlConnection = System.Data.SqlClient.SqlConnection;

namespace GestionProjet.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            LogPrUsTskComb combinedModel = new LogPrUsTskComb();

            Project project = new Project();

            combinedModel.ProjectsList = project.getProjectsFromDatabase();

            User user = new User();

            combinedModel.UsersList = user.getUsersFromDatabase();

            Task task = new Task();

            combinedModel.TasksList = task.getTasksFromDatabase();

            combinedModel.Login = new Login();

            return View(combinedModel);
        }

        [HttpPost]
        public ActionResult Index(LogPrUsTskComb combinedModel)
        {
            string userID = combinedModel.Login.UserID;
            string password = combinedModel.Login.Password;

            if (testLogin(userID, password))
            {
                combinedModel.Login.Message = "Authentification valide";
            }
            else
            {
                combinedModel.Login.Message = "Authentification invalide";
            }
            Project project = new Project();

            combinedModel.ProjectsList = project.getProjectsFromDatabase();

            User user = new User();

            combinedModel.UsersList = user.getUsersFromDatabase();

            Task task = new Task();

            combinedModel.TasksList = task.getTasksFromDatabase();

            return View(combinedModel);
        }

        private bool testLogin(string userID, string password)
        {
            userID = userID == null ? "" : userID.Trim();
            password = password == null ? "" : password.Trim();

            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                    conn.Open();

                    string query = @"select * from Login";

                    SqlCommand command = new SqlCommand(query, conn);

                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            string storedUserID = reader[0] == null ? "" : reader[0].ToString().Trim();
                            string storedPassw = reader[1] == null ? "" : reader[1].ToString().Trim();

                            if (storedUserID == userID && storedPassw == password)
                            {
                                return true;
                            }
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
            return false;
        }
    }
}