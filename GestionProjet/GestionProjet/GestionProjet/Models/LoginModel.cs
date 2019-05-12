﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionProjet.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Nom d'utilisateur est obligatoire")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mot de passe est obligatoire")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}