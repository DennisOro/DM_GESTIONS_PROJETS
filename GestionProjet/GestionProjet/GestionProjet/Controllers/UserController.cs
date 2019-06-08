using GestionProjet.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace GestionProjet.Controllers
{
    public class UserController : Controller
    {
        //TLS 1.2 support for .NET 3.5
        public const SslProtocols _Tls12 = (SslProtocols)0x00000C00;
        public const SecurityProtocolType Tls12 = (SecurityProtocolType)_Tls12;

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
        
        public string ValidCodePostal(string codepostal)
        {
            string result = "f";
            ServicePointManager.SecurityProtocol = Tls12;

            // Your username and password are imported from the following file
            // CPCWS_PostOffice_DotNet_Samples\REST\postoffice\user.xml  
                var username = "7863e2eeb30be653";// ConfigurationSettings.AppSettings["username"];
            var password = "fcdc6870f7829df2eed94f";// ConfigurationSettings.AppSettings["password"];

            // REST URI
            var url = "https://ct.soa-gw.canadapost.ca/rs/postoffice?postalCode="+ codepostal + "&maximum=1";

            var method = "GET"; // HTTP Method
            String responseAsString = ".NET Framework " + Environment.Version.ToString() + "\r\n\r\n";

            try
            {
                // Create REST Request
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = method;

                // Set Basic Authentication Header using username and password variables
                string auth = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(username + ":" + password));
                request.Headers = new WebHeaderCollection();
                request.Headers.Add("Authorization", auth);
                request.Headers.Add("Accept-Language", "fr-CA");
                request.Accept = "application/vnd.cpc.postoffice+xml";

                // Execute REST Request
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                // Deserialize xml response to postofficelist object
                XmlSerializer serializer = new XmlSerializer(typeof(postofficelist));
                TextReader reader = new StreamReader(response.GetResponseStream());
                postofficelist postOfficeList = (postofficelist)serializer.Deserialize(reader);

                // Retrieve values from postofficelist object
                foreach (var postOffice in postOfficeList.postoffice)
                {
                    /*responseAsString += "Office Name: " + postOffice.name + "\r\n";
                    responseAsString += "Office Id: " + postOffice.officeid + "\r\n";
                    responseAsString += "Address: " + postOffice.address.officeaddress + "\r\n\r\n";*/
                    result = "t";
                }
            }
            catch (WebException webEx)
            {
                HttpWebResponse response = (HttpWebResponse)webEx.Response;
                
                if (response != null)
                {
                    responseAsString += "HTTP  Response Status: " + webEx.Message + "\r\n";

                    // Retrieve errors from messages object
                    try
                    {
                        // Deserialize xml response to messages object
                        XmlSerializer serializer = new XmlSerializer(typeof(messages));
                        TextReader reader = new StreamReader(response.GetResponseStream());
                        messages myMessages = (messages)serializer.Deserialize(reader);


                        if (myMessages.message != null)
                        {
                            foreach (var item in myMessages.message)
                            {
                                responseAsString += "Error Code: " + item.code + "\r\n";
                                responseAsString += "Error Msg: " + item.description + "\r\n";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Misc Exception
                        responseAsString += "ERROR: " + ex.Message;
                    }
                }
                else
                {
                    // Invalid Request
                    responseAsString += "ERROR: " + webEx.Message;
                }

            }
            catch (Exception ex)
            {
                // Misc Exception
                responseAsString += "ERROR: " + ex.Message;
            }

            //Console.WriteLine(responseAsString);
            //Console.WriteLine("Press any key to continue...");
            //Console.ReadKey(true);



            return result;
        }
        
    }
}