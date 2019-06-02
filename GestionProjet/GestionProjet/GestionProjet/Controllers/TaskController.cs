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
        public ActionResult Task(string description, int idProjet)
        {
            Task newTask = new Task();

            newTask = newTask.getTaskInfo(description, idProjet);

            return View(newTask);
        }
    }
}