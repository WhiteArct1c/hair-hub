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
            "User Id=aep9swyijqaf5a8dok66;database=hairhubdb; " +
            "password=pscale_pw_SxFUATnB7xwwnPUfwOOGJSEwNUeZhyiBwxWC2e7rQ5a"
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
