using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using System;

namespace HairHub.db
{
    class ConnDB
    {
        private static MySqlConnection connectionString = new MySqlConnection(
            "server=aws.connect.psdb.cloud;" +
            "User Id=jvykim8qv9iapcy5won7;database=hairhubdb;" +
            "password=pscale_pw_rfitZ9nJriTWJZdvu53j1XgJ2K0cdA3rLjRlT4L8Lb3"
            );

        public static MySqlConnection openConnection()
        {
            if(connectionString.State != ConnectionState.Open)
            {
                try
                {
                    connectionString.Open();
                    return connectionString;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return connectionString;
        }

        public static void closeConnection()
        {
            connectionString.Close();
        }
    }
}
