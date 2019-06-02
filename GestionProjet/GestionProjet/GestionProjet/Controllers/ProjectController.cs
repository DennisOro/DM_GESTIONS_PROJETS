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

        public ActionResult Project(int projectId)
        {

            Project thisProject = new Project();
            thisProject = thisProject.getProjectInfo(projectId);

            if(projectId != 0)
                return View(thisProject);
            else 
                return View();
        }

        [HttpPost]
        public ActionResult Project(Project project)
        {
            Project thisProject = new Project();

            if (project.ProjectId == 0)
            {
                thisProject = thisProject.createProject(project);
                ViewBag.Message = "Projet est crée!";

            }
            else
            {
                thisProject = thisProject.updateProject(project);
            }

            return View(thisProject);
        }

    }
}