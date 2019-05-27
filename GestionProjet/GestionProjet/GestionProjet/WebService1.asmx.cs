using GestionProjet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace GestionProjet
{
    /// <summary>
    /// Description résumée de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebGet(UriTemplate = "/Login/{UserID}/{Password}")]
        public String testLogin(string userID, string password)
        {
            Login login = new Login();

            string matricule = login.getUserMatricule(userID, password);

            User user = new User();

            user = user.getUserInfoByID(matricule);

            List<string> output = new List<string>();

            //if (login.testLogin(userID, password))
            if (matricule != "")
            {
                output.Add("1");
                output.Add(user.FirstName);
            }
            else
            {
                output.Add("0");
                output.Add("Fail");
            }

            return new JavaScriptSerializer().Serialize(output);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat= ResponseFormat.Json)]
        public void Login(string userID, string password)
        {
            Login login = new Login();

            string matricule = login.getUserMatricule(userID, password);

            string result = Newtonsoft.Json.JsonConvert.SerializeObject(login);
            Context.Response.Write(result);

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void ListeTask(string userID)
        {
            TaskUserPrj taskUserPrj = new TaskUserPrj();
            List<TaskUserPrj> tasksList = new List<TaskUserPrj>();
            tasksList = taskUserPrj.getTaskUserPrj(userID);

            string result = Newtonsoft.Json.JsonConvert.SerializeObject(tasksList);
            Context.Response.Write(result);

        }
    }
}
