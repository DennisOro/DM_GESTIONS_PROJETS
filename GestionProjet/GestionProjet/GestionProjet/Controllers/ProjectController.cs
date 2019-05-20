using GestionProjet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionProjet.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        //public ActionResult Project()
        //{
        //    return View();
        //}

        public ActionResult Project(int projectId )
        {

            Project thisProject = new Project();
            thisProject = thisProject.getProjectInfo(projectId);

            return View(thisProject);
        }
    }
}