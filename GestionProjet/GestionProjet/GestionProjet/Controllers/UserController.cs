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

        public ActionResult User(string firstName, string lastName)
        {

            User thisUser = new User();
            thisUser = thisUser.getUserInfoByName(firstName, lastName);

            return View(thisUser);
        }
    }
}