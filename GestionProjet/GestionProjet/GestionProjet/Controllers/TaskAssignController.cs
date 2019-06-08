using GestionProjet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionProjet.Controllers
{
    public class TaskAssignController : Controller
    {
        // GET: Task

        // controleur pour la view d'assignation des tâches
        public ActionResult TaskAssign(string description, int idProjet, bool newTask)
        {
            TaskAssign thisTask = new TaskAssign();
            thisTask = thisTask.getTaskInfo(description, idProjet);
            thisTask.NewTask = newTask;
            TaskUser taskUser = new TaskUser();
            thisTask.TaskUserList = taskUser.getTaskUser(thisTask.IdTask);

            return View(thisTask);
        }


        // Action du contrôleur qui permet d'ajouter une tâche de projet
        [HttpPost]
        public ActionResult TaskAssign(TaskAssign task)
        {
                task.addTaskUser(task);


            return Content(@"<body>
                       <script type='text/javascript'>
                        alert('Les données ont été enregistrées.');
                         window.close();
                       </script>
                     </body> ");
        }





    }
}