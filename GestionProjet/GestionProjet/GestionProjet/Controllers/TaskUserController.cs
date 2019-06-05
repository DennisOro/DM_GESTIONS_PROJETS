using GestionProjet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionProjet.Controllers
{
    public class TaskUserController : Controller
    {
        TaskUserPrj taskUserPrj = new TaskUserPrj();
        // GET: TaskUser
        public ActionResult TaskUser(string description, int idProjet, bool newTask, string UserID)
        {
            Task thisTask = new Task();

            thisTask = thisTask.getTaskInfo(description, idProjet);
            thisTask.NewTask = newTask;
            thisTask.Login = UserID;

            taskUserPrj.getTaskUserPrjById(thisTask.IdTask, UserID);

            return View(thisTask);
        }

        [HttpPost]
        public ActionResult TaskUser(Task task)
        {
            if (task.nbHeures­­­>0)
            {
                taskUserPrj.UpdateHrsTask(task.Login, task.IdTask,task.nbHeures, task.idStatus);
            }


            //return View(task);
            //return View("Close");
            return Content(@"<body>
                       <script type='text/javascript'>
                        alert('Les données ont été enregistrées.');
                         window.close();
                       </script>
                     </body> ");
        }



    }

}