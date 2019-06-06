using GestionProjet.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;


namespace GestionProjet.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var model = await this.GetCombinedModel();

            return this.View(model);
        }

        //[HttpPost]
        public async Task<ActionResult> GetTasksForProject(int projectId, string loginRole)
        {
            var model = await this.GetCombinedModel(projectId, loginRole);

            return PartialView("TasksList", model);
        }

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
            if (combinedModel.Login.Role == "Utilisateur") {
                combinedModel.ProjectsList = project.getProjectsByLogin(userID);
                combinedModel.TasksList = task.getAllTasksByLogin(userID);
            }
            else {
                combinedModel.ProjectsList = project.getProjectsFromDatabase();
                combinedModel.TasksList = task.getAllTasksFromDatabase();
            }

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
            Models.Task task = new Models.Task();

            if (task.deleteTask(idTask))
                return "La tache est supprimée.";
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