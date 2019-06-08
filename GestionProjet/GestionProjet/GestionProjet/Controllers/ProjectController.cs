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

            return View(thisProject);
        }

        [HttpPost]
        public ActionResult Project(Project project)
        {
            string message = "";

            if (project.ProjectId == 0)
            {
                if(project.createProject(project))
                {
                    message = "Projet a été créé avec succès.";
                }
                else
                {
                    message = "Création de projet a été échoué, contactez le programmeur du système.";
                }
            }
            else
            {
                if (project.updateProject(project))
                {
                    message = "Projet a été modifié avec succès.";
                }
                else
                {
                    message = "Modification de projet a été échoué, contactez le programmeur du système.";
                }
            }

            return Content(@"<body>
                       <script type='text/javascript'>
                        alert('" + message + "'); window.close(); </script> </body> ");
        }

    }
}