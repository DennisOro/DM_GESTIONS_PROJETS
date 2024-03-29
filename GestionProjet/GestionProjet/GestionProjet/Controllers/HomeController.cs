﻿using GestionProjet.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

//cette classe est le controlleur de la page d'acceuil, sert à générer les pages et à peupler les données
namespace GestionProjet.Controllers
{
    public class HomeController : Controller
    {
        // Pour la méthode Get dans les formulaires
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var model = await this.GetCombinedModel();

            return this.View(model);
        }

        // Pour la méthode Post dans les formulaires
        //[HttpPost]
        public async Task<ActionResult> GetTasksForProject(int projectId, string loginRole)
        {
            var model = await this.GetCombinedModel(projectId, loginRole);

            return PartialView("TasksList", model);
        }

        // Ce controleur va chercher les taches par projet

        [HttpGet]
        private async Task<LogPrUsTskComb> GetCombinedModel(int projectId = 0, string loginRole = null)
        {
            LogPrUsTskComb combinedModel = new LogPrUsTskComb();

            Project project = new Project();

            combinedModel.ProjectsList = project.getProjectsFromDatabase();

            User user = new User();

            combinedModel.UsersList = user.getUsersFromDatabase();

            Models.Task task = new Models.Task();

            if(projectId == 0)
                combinedModel.TasksList = task.getAllTasksFromDatabase();
            else
                combinedModel.TasksList = task.getTasksListForProject(projectId);

            combinedModel.Login = new Login();

            if (loginRole != null)
                combinedModel.Login.Role = loginRole;

            return combinedModel;
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

        // Pour gérer l'authentification de l'utilisateur
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

            User user = new User();

            combinedModel.UsersList = user.getUsersFromDatabase();

            Project project = new Project();
            Models.Task task = new Models.Task();
            Models.Client client = new Models.Client();

            if (combinedModel.Login.Role == "Utilisateur") {
                combinedModel.ProjectsList = project.getProjectsByLogin(userID);
                combinedModel.TasksList = task.getAllTasksByLogin(userID);
            }
            else {
                combinedModel.ProjectsList = project.getProjectsFromDatabase();
                combinedModel.TasksList = task.getAllTasksFromDatabase();
                combinedModel.ClientsList = client.getClientsFromDatabase();
            }

            return View(combinedModel);
        }

        public string deleteProject(int projectId)
        {
            Project project = new Project();

            if(project.deleteProject(projectId))
                return "Le projet a été supprimé.";
            else
                return "Le projet ne peut pas être supprimé.";
        }

        public string deleteTaskUser(int idTask, string matricule)
        {
            TaskUser taskUser = new TaskUser();

            if (taskUser.deleteTaskUser(idTask, matricule))
                return "L'employé a été supprimé.";
            else
                return "L'employé ne peut pas être supprimé.";
        }


        public string deleteUser(string firstName, string lastName)
        {
            User user = new User();

            if (user.deleteUser(firstName, lastName))
                return "L'employé a été supprimé.";
            else
                return "L'employé ne peut pas être supprimé.";
        }

        public string deleteTask(int idTask)
        {
            Models.Task task = new Models.Task();

            if (task.deleteTask(idTask))
                return "La tache a été supprimée.";
            else
                return "La tache ne peut pas être supprimée.";
        }

        public string getTasksListForProject(int idProject)
        {
            Models.Task task = new Models.Task();
            List<Models.Task> tasksList = task.getTasksListForProject(idProject);

            //Index(idProject);

            RedirectToAction("Index", "Home");

            return new JavaScriptSerializer().Serialize(tasksList);
        }
    }
}