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
            "User Id=19uvw83cwiyiuznaza4s;database=hairhubdb;" +
            "password=pscale_pw_v0z4WeUYExmfegWnGq1f5Zt10QvJrx2wPenoraGA1S2"
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
