using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionProjet.Models
{
    public class LogPrUsTskComb
    {
        public Login Login { get; set; }
        public List<Project> ProjectsList { get; set; }
        public List<Project> UsersList { get; set; }
        public List<Project> TasksList { get; set; }


    }
}