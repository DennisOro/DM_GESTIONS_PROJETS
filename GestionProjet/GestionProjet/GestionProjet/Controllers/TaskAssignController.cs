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

            return View(thisTask);
        }



        [HttpPost]
        public ActionResult TaskAssign(TaskAssign task)
        {
            if (task.NewTask == false)
            {
                task.addTask(task);
            }






            return Content(@"<body>
                       <script type='text/javascript'>
                        alert('Les données ont été enregistrées.');
                         window.close();
                       </script>
                     </body> ");
        }





    }
}