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

            /*
             * <<<<<<< Updated upstream
             */
            combinedModel.Login = new Login();
        /*}

        public ActionResult About()
        {
            ViewBag.Message = "Application pour la gestion de projets";
/*>>>>>>> Stashed changes

    */

            return View(combinedModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Application pour la gestion de projets";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Application pour la gestion de projets";
            return View();
        }


        [HttpPost]
        public ActionResult Index(LogPrUsTskComb combinedModel)
        {
            string userID = combinedModel.Login.UserID;
            string password = combinedModel.Login.Password;

            Login login = new Login();

            if (login.testLogin(userID, password))
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

        
    }
}