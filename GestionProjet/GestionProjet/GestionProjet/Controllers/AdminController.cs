using GestionProjet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionProjet.Controllers
{
    public class AdminController : Controller
    {

        // GET: Admin
        [HttpGet]
        public ActionResult Admin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Admin(FormCollection formCollection)
        {
            Admin employe = new Admin();
            employe.matricule = Convert.ToInt32(formCollection["Matricule"]);
            employe.nom = formCollection["Nom"];
            employe.prenom = formCollection["Prenom"];
            employe.login = formCollection["Login"];
            employe.motDePasse  = formCollection["MotDePasse"];
            employe.role = formCollection["Role"];
            AjouterEmploye(employe);
            return View();
        }

        public void AjouterEmploye(Admin employe)
        {

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;



                SqlCommand cmd = new SqlCommand("spCreerEmploye", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramNom = new SqlParameter();
                paramNom.ParameterName = "@nom";
                paramNom.Value = employe.nom;
                cmd.Parameters.Add(paramNom);

                SqlParameter paramPrenom = new SqlParameter();
                paramPrenom.ParameterName = "@prenom";
                paramPrenom.Value = employe.prenom;
                cmd.Parameters.Add(paramPrenom);

                SqlParameter paramLogin = new SqlParameter();
                paramLogin.ParameterName = "@login";
                paramLogin.Value = employe.login;
                cmd.Parameters.Add(paramLogin);

                SqlParameter parammotDePasse = new SqlParameter();
                parammotDePasse.ParameterName = "@motDePasse";
                parammotDePasse.Value = employe.motDePasse;
                cmd.Parameters.Add(parammotDePasse);

                SqlParameter paramIdUser = new SqlParameter();
                paramIdUser.ParameterName = "@idUser";
                paramIdUser.Value = employe.matricule;
                cmd.Parameters.Add(paramIdUser);

                SqlParameter paramRole = new SqlParameter();
                paramRole.ParameterName = "@role";
                paramRole.Value = employe.role;
                cmd.Parameters.Add(paramIdUser);

                SqlParameter paramTaux = new SqlParameter();
                paramTaux.ParameterName = "@tauxHoraire";
                paramTaux.Value = employe.role;
                cmd.Parameters.Add(paramTaux);


                conn.Open();
                cmd.ExecuteNonQuery();

            }
        }




    }
}