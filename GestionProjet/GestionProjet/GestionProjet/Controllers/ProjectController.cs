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
        //[Http]
        //public ActionResult Project()
        //{
        //    return View();
        //}

        public ActionResult Project(int projectId)
        {

            Project thisProject = new Project();
            thisProject = thisProject.getProjectInfo(projectId);

            return View(thisProject);
        }

        [HttpPost]
        public ActionResult Project(Project project)
        {
            Project thisProject = new Project();

            if (project.ProjectId == 0)
            {
                thisProject = thisProject.createProject(project);
            }
            else
            {
                thisProject = thisProject.updateProject(project);
            }

            return View(thisProject);
        }



    }
}