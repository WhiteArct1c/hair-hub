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
            "User Id=atjvoax3y61mv6n7m5cf;database=hairhubdb; " +
            "password=pscale_pw_5GZ2qlzeC4mPx4hqObyYNbMMEp8hiipcNMv6BkWIv1o"
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
