using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionProjet.Models
{
    /*
    Classe permettant de definir le string de connection a la bd
    */
    public static class SqlDatabaseConnection
    {
        //public static string CONNECTIONSTRING = @"Data Source=LADO\SQLEXPRESS; Initial Catalog=INF6150; Integrated Security=SSPI;";
        public static string CONNECTIONSTRING = @"Data Source=DESKTOP-275FO6M\SQLEXPRESS; Initial Catalog=INF6150; Integrated Security=SSPI;";
        //public static string CONNECTIONSTRING = @"Data Source=172.29.111.49,1433; Initial Catalog=INF6150; Network Library=DBMSSOCN; User ID=Lado_login; Password=pass";


    }
}