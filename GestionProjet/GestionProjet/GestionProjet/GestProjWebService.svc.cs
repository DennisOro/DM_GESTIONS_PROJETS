using GestionProjet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;

namespace GestionProjet
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class GestProjWebService
    {
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract]
        public void DoWork()
        {
            // Add your operation implementation here
            return;
        }

        // Add more operations here and mark them with [OperationContract]

        [WebGet(UriTemplate = "/User")]
        public String GetAllUsers()
        {
            User user = new User();

            List<User> usersList = user.getUsersFromDatabase();

            string output = new JavaScriptSerializer().Serialize(usersList);

            return output;
        }

        [WebGet(UriTemplate = "/Login/{UserID}/{Password}")]
        public String testLogin(string userID, string password)
        {
            Login login = new Login();

            string matricule = login.getUserMatricule(userID, password);

            User user = new User();

            user = user.getUserInfo(matricule);

            List<string> output = new List<string>();

            if (login.testLogin(userID, password))
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


    }
}
