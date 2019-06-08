using GestionProjet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionProjet.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult Task(string description, int idProjet, bool newTask)
        {
            Task thisTask = new Task();

            thisTask = thisTask.getTaskInfo(description, idProjet);
            thisTask.NewTask = newTask;

            return View(thisTask);
        }
        // controleur pour la view d'assignation des tâches
        public ActionResult TaskAssign(string description, int idProjet, bool newTask)
        {
            Task thisTask = new Task();
            thisTask = thisTask.getTaskInfo(description, idProjet);
            thisTask.NewTask = newTask;

            return View(thisTask);
        }

        [HttpPost]
        public new ActionResult Task(Task task)
        {
            string message = "";

            if (task.NewTask)
            {
                if(task.createTask(task))
                {
                    message = "La tache a été créé avec succès.";
                }
                else
                {
                    message = "Création de tache a été échoué, contactez le programmeur du système.";
                }
            }
            else 
            {
                if(task.updateTask(task))
                {
                    message = "La tache a été modifié avec succès.";
                }
                else
                {
                    message = "Modification de tache a été échouée, contactez le programmeur du système.";
                }
            }

            return Content(@"<body>
                       <script type='text/javascript'>
                        alert('" + message + "'); window.close(); </script> </body> ");
        }

        [HttpPost]
        public ActionResult TaskAssign(Task task)
        {
            if (!task.NewTask)
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