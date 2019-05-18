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
            LogPrUsTskComb loginProjectComb = new LogPrUsTskComb();

            loginProjectComb.ProjectsList = getProjectsFromDatabase();

            loginProjectComb.Login = new Login();

            return View(loginProjectComb);
        }

        [HttpPost]
        public ActionResult Index(LogPrUsTskComb loginProjectComb)
        {
            string userID = loginProjectComb.Login.UserID;
            string password = loginProjectComb.Login.Password;

            if (testLogin(userID, password))
            {
                loginProjectComb.Login.Message = "Authentification valide";
            }
            else
            {
                loginProjectComb.Login.Message = "Authentification invalide";
            }

            loginProjectComb.ProjectsList = getProjectsFromDatabase();

            return View(loginProjectComb);
        }

       

        private List<Project> getProjectsFromDatabase()
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