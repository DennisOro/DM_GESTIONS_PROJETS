using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GestionProjet.Models
{
    public class Client
    {
        public string NomClient { get; set; }
        public int ClientId { get; set; }

        public bool NewClient { get; set; }

        public List<Client> getClientsFromDatabase()
        {
            List<Client> ClientsList = new List<Client>();
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                    conn.Open();

                    string query = @"select * from [Client]";

                    SqlCommand command = new SqlCommand(query, conn);

                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            ClientsList.Add(new Client()
                            {
                                ClientId = reader[0] == null ? 0 : Convert.ToInt32(reader[0]),
                                NomClient = reader[1] == null ? "" : reader[1].ToString().Trim(),

                            });
                        }
                    }
                    finally
                    {
                        reader.Close();
                    }

                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return ClientsList;

        }

        public Client getClientInfo(string query)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                    conn.Open();

                    SqlCommand command = new SqlCommand(query, conn);

                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        if (reader.Read())
                        {
                            ClientId = reader[0] == null ? 0 : Convert.ToInt32(reader[0]);
                            NomClient = reader[1] == null ? "" : reader[1].ToString().Trim();
                        }
                        else
                        {
                            ClientId = 0;
                            NomClient = "";

                        }
                    }
                    finally
                    {
                        reader.Close();
                    }

                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return this;
        }

        public Client getClientInfoByID(string clientId)
        {
            string query = @"select * from [Client] where idClient = '" + clientId + "'";
            return getClientInfo(query);
        }

        public bool updateClient(Client client)
        {
            try
            {

                string nomClient = client.NomClient == null ? "" : client.NomClient.Trim();
                string updateQuery = @"UPDATE [INF6150].[dbo].[Client]  SET nomClient = '" + nomClient + "'"
                                                                        + "WHERE idClient = '" + client.ClientId + "'";


                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                    conn.Open();

                    SqlCommand command = new SqlCommand(updateQuery, conn);

                    command.ExecuteNonQuery();

                    conn.Close();
                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        public bool createClient(Client client)
        {
            // test if matricule does not exist

            if (client != null)
            {
                string createQuery = @"INSERT INTO [INF6150].[dbo].[Client] (idClient,nomClient)"
                                     + "VALUES ('" + client.ClientId + "','" + client.NomClient + "')";

                try
                {
                    using (SqlConnection conn = new SqlConnection())
                    {
                        conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                        conn.Open();

                        SqlCommand command = new SqlCommand(createQuery, conn);

                        command.ExecuteNonQuery();

                        conn.Close();

                        return true;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return false;
        }

        public bool IdClientExists(int idClient)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                    conn.Open();

                    string query = @"select idClient from [Client] where idClient = '" + idClient + "'";

                    SqlCommand command = new SqlCommand(query, conn);

                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        if (reader.HasRows)
                            return true;
                    }
                    finally
                    {
                        reader.Close();
                    }

                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        public bool deleteClient(Client newClient)
        {
            string deleteQuery = @" delete from [INF6150].[dbo].[Client] where idClient = '" + newClient.ClientId + "';"
                                 + "delete from [INF6150].[dbo].[Project] where idClient = '" + newClient.ClientId + "'";

            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = SqlDatabaseConnection.CONNECTIONSTRING;

                    conn.Open();

                    SqlCommand command = new SqlCommand(deleteQuery, conn);

                    command.ExecuteNonQuery();

                    conn.Close();

                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }


    }
}