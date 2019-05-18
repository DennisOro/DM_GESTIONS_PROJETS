using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionProjet.Models
{
    public class Task
    {
        public int IdTask { get; set; }
        public string Description { get; set; }
        public int NBAssignedUsers { get; set; }
        public bool Status { get; set; }
    }
}