using GestionProjet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionProjet.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        //public ActionResult User()
        //{
        //    return View();
        //}
        // Controlleur pour gérer la vue de l'utilisateur
        public new ActionResult User(string firstName, string lastName, bool newUser)
        {

            User thisUser = new User();
            thisUser = thisUser.getUserInfoByName(firstName, lastName);
            thisUser.NewUser = newUser;
            thisUser.setSelectedRole(ref thisUser);
            thisUser.Login = new Login();


            return View(thisUser);
        }

        // Mettre à jour l'utilisateur(modifier, supprimer, effacer)
        [HttpPost]
        public new ActionResult User(User user)
        {
            string message = "";
            //User thisUser = new User();

            string selectedRole = user.Role.ToString();

            if (user.NewUser)
            {
                message = createUser(user, message);
            }
            else
            {
                if (user.updateUser(user))
                    message = "Empoyé a été modifié avec succès.";
                else
                    message = "Modification a été échoué, contactez le programmeur du système. ";
            }

            return Content(@"<body>
                       <script type='text/javascript'>
                        alert('" + message + "'); window.close(); </script> </body> ");
        }

        private string createUser(User user, string message)
        {
            // On ne peut pas creer un utilisateur avec si son matricule existe déjà
            if (user.matriculeExists(user.matricule))
            {
                message = "Empoyé avec ce matricule existe déjà. Veiller recommencer.";
            }
            else
            {
                if (user.createUser(user))
                {
                    if (user.Login.userNameExists(user.Login.UserID))
                    {
                        message = "Empoyé avec ce nom utilisateur existe déjà. Veiller recommencer.";
                        user.deleteUser(user); // suppression de user créé precedement
                        
                    }
                    else
                    {
                        if (user.Login.createUserLogin(user))
                        {
                            message = "Empoyé a été créé avec succès.";
                        }
                        else
                        {
                            message = "Création de login a été échoué, contactez le programmeur du système.";
                            user.deleteUser(user); // suppression de user créé precedement
                        }
                    }

                }
                else
                {
                    message = "Création employé a été échoué, contactez le programmeur du système.";
                }
            }
            

            return message;
        }
    }
}