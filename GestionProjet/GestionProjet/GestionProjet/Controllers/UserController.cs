using GestionProjet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionProjet.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        //public ActionResult User()
        //{
        //    return View();
        //}

        public new ActionResult User(string firstName, string lastName)
        {

            User thisUser = new User();
            thisUser = thisUser.getUserInfoByName(firstName, lastName);

            return View(thisUser);
        }

        [HttpPost]
        public new ActionResult User(User user)
        {
            User thisUser = new User();
            /*
            if (project.ProjectId == 0)
            {
                thisProject = thisProject.createProject(project);
            }
            else
            {
                thisProject = thisProject.updateProject(project);
            }
            */
            return View(thisUser);
        }
    }
}