using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionProjet.Models
{
    public class LoginProjectComb
    {
        public Login Login { get; set; }
        public List<Project> projectsList { get; set; }
    }
}