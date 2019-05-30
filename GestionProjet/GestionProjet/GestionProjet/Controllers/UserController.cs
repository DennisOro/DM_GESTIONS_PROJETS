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

        public new ActionResult User(string firstName, string lastName, bool newUser)
        {

            User thisUser = new User();
            thisUser = thisUser.getUserInfoByName(firstName, lastName);
            thisUser.NewUser = newUser;
            thisUser.setSelectedRole(ref thisUser);


            return View(thisUser);
        }

        [HttpPost]
        public new ActionResult User(User user)
        {
            //User thisUser = new User();

            string selectedRole = user.Role.ToString();

            if (user.NewUser)
            {
                user = user.createUser(user);
            }
            else
            {
                user = user.updateUser(user);
            }
            //user.setSelectedRole(ref user);
            //user.Role = 

            return View(user);
        }
    }
}