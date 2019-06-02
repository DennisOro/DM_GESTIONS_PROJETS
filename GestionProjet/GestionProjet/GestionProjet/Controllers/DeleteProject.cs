using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GestionProjet.Models;


namespace GestionProjet.Controllers
{
    public class DeleteProject
    {

        public string deleteProject(string projectId)
        {

            Project project = new Project();

            return "Projet est supprimé";
        }
    }
}