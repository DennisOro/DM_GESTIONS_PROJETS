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

        [HttpPost]
        public new ActionResult Task(Task task)
        {
            if(task.NewTask)
            {
                task.createTask(task);
            }
            else
            {
                task.updateTask(task);
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