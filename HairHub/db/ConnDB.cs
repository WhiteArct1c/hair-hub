using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace HairHub.db
{
    class ConnDB
    {
        private MySqlConnection connectionString = new MySqlConnection(
                "server=aws.connect.psdb.cloud;" +
            "User Id=ophhbmiu03mqrm5rbcpf;database=hairhubdb; " +
            "password=pscale_pw_QjFvyCbizFKhEypqHJPwbDlr6T3PzCjmJSVWjOhflZw"
            );

        public MySqlConnection getConnection()
        {
            if(this.connectionString.State == ConnectionState.Open)
            {
                this.connectionString.Close();
            }

            return this.connectionString;
        }
    }
}
