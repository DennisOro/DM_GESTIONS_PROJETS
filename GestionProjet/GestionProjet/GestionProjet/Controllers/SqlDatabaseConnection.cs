using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GestionProjet.Controllers
{
    public static class SqlDatabaseConnection
    {
        public static string CONNECTIONSTRING = @"Data Source=LADO\SQLEXPRESS; Initial Catalog=ProjectDatabase; Integrated Security=SSPI;";

        /*

        public SqlConnection connectToDatabase()
        {
            SqlConnection conn = null;
            try
            {
                using (conn = new SqlConnection())
                {
                    conn.ConnectionString = connectionString;

                    conn.Open();
                }

                    Console.WriteLine("Connection Open  !");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return conn;
        }
        */
    }
}