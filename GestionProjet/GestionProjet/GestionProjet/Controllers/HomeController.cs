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
            dynamic dynamicModel = new ExpandoObject();

            List<Project> projectsList = getProjectsFromDatabase();

            dynamicModel.Login = new Login();

            dynamicModel.projectsList = getProjectsFromDatabase();

            dynamicModel.Login.Message = "ssssss";

            return View(dynamicModel);
        }

        [HttpPost]
        public ActionResult Index(dynamic dynamicModel)
        {
            string userID = Request["userIDText"];
            string password = Request["password"];

            string message = "";

            if (testLogin(userID, password))
            {
                //dynamicModel.Login.Message = "Authentification valide";
                message = "Authentification valide";
            }
            else
            {
                message = "Authentification invalide";
            }

            Login login = new Login();
            login.Message = message;

            ViewData["MyLogin"] = login;

            return View(dynamicModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login loginModel)
        {
            
            if (testLogin(loginModel.UserID, loginModel.Password))
            {
                loginModel.Message = "Authentification valide";
            }
            else
            {
                loginModel.Message = "Authentification invalide";
            }
            

            return View(loginModel);
        }

        private List<Project> getProjectsFromDatabase()
        {
            List<Project> projectsList = new List<Project>();
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
                            projectsList.Add(new Project() { ProjectId = Convert.ToInt32(reader[0]), ProjectName = reader[1].ToString() });
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