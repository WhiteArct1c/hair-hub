using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace HairHub.db
{
    class ConnDB
    {
        public static MySqlConnection connectionString = new MySqlConnection(
                "server=aws.connect.psdb.cloud;" +
            "User Id=ophhbmiu03mqrm5rbcpf;database=hairhubdb; " +
            "password=pscale_pw_QjFvyCbizFKhEypqHJPwbDlr6T3PzCjmJSVWjOhflZw"
            );

        public static void openConnection()
        {
            if(connectionString.State != ConnectionState.Open)
            {
                connectionString.Open();
            }
        }

        public static void closeConnection()
        {
            connectionString.Close();
        }
    }
}
