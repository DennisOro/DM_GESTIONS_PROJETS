using GestionProjet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionProjet.Controllers
{
    public class ClientController : Controller
    {
        public new ActionResult Client(String idClient, bool newClient)
        {

            Client thisClient = new Client();
            thisClient = thisClient.getClientInfoByID(idClient);
            thisClient.NewClient = newClient;


            return View(thisClient);
        }
        [HttpPost]
        public new ActionResult Client(Client client)
        {
            string message = "";
            //User thisUser = new User();



            if (client.ClientId==0)
            {
                message = createClient(client, message);
            }
            else
            {
                if (client.updateClient(client))
                    message = "Client a été modifié avec succès.";
                else
                    message = "Modification a été échoué, contactez le programmeur du système. ";
            }

            return Content(@"<body>
                       <script type='text/javascript'>
                        alert('" + message + "'); window.close(); </script> </body> ");
        }

        private string createClient(Client client, string message)
        {
            if (client.IdClientExists(client.ClientId))
            {
                message = "Client avec cet id existe déjà. Veiller recommencer.";
            }
            else
            {
                message = "Création client a été échoué, contactez le programmeur du système.";
                client.createClient(client);
            }


            return message;
        }


    }
}