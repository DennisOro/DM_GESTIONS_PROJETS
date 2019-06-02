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

        /*navigation de l'application, pages a propos et contact*/
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
                combinedModel.Login.AuthentificationValide = true;
                string matricule = login.getUserMatricule(userID, password);
                combinedModel.Login.Role = login.testUserRole(matricule);
            }
            else
            {
                combinedModel.Login.Message = "Authentification invalide";
                return View(combinedModel);
            }
            Project project = new Project();

            combinedModel.ProjectsList = project.getProjectsFromDatabase();

            User user = new User();

            combinedModel.UsersList = user.getUsersFromDatabase();

            Task task = new Task();

            combinedModel.TasksList = task.getTasksFromDatabase();

            return View(combinedModel);
        }

        public string deleteProject(int projectId)
        {
            Project project = new Project();

            if(project.deleteProject(projectId))
                return "Le projet est supprimé.";
            else
                return "Le projet ne peut pas être supprimé.";
        }

        public string deleteUser(string firstName, string lastName)
        {
            User user = new User();

            if (user.deleteUser(firstName, lastName))
                return "L'employé est supprimé.";
            else
                return "L'employé ne peut pas être supprimé.";
        }

        public string deleteTask(int idTask)
        {
            Task task = new Task();

            if (task.deleteTask(idTask))
                return "La tache est supprimée.";
            else
                return "La tache ne peut pas être supprimée.";
        }
    }
}