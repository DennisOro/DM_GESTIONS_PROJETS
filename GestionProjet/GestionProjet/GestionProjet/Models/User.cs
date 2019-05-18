using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionProjet.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IDUser { get; set; }
        public int HourlyRate { get; set; }
        public string Role { get; set; }
    }
}