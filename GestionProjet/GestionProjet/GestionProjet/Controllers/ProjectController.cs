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

        public ActionResult Project(int projectId, bool deleteProject)
        {

            Project thisProject = new Project();
            thisProject = thisProject.getProjectInfo(projectId);

            if (deleteProject)
            {
                thisProject.deleteProject(projectId);
                ViewBag.Message = "Ce Projet est supprimé!";
                return RedirectToAction("Index", "Home");
            }

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
/*
        [HttpPost]
        [ActionName("Project")]
        //[OnAction(ButtonName = "Create")]
        public ActionResult Delete(Project project)
        {
            //Project thisProject = new Project();
            //thisProject.deleteProject(projectId);

            return View();
        }
*/
    }
}