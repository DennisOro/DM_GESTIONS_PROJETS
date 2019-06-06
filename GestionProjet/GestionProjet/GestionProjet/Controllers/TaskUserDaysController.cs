using GestionProjet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionProjet.Controllers
{
    public class TaskUserDaysController : Controller
    {
        // GET: TaskUserDay
        [HttpPost]
        public ActionResult TaskUserDays(Login login)
        {
            string userID = login.UserID;
            string dateFT = login.DateFT;

            TaskUserDays taskUserDays = new TaskUserDays();
            List<TaskUserDays> listTaskDays = taskUserDays.getTaskUserHrs(userID, dateFT);

            return View(listTaskDays);
            //return new RazorPDF.PdfResult(listTaskDays, "TaskUserDays");
        }
    }
}