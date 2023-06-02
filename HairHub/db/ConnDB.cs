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
            "User Id=sv0i9tznkqgflzxfablx;database=hairhubdb;" +
            "password=pscale_pw_CLfYSHyDONde5kR179NbaZaqKBWvi3rKVMdLT8h5irX"
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
