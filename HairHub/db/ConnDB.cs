﻿using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using System;

namespace HairHub.db
{
    class ConnDB
    {
        private static MySqlConnection connectionString = new MySqlConnection(
            "server=aws.connect.psdb.cloud;" +
            "User Id=q3h8dqgxql2a8t3v77ra;database=hairhubdb;" +
            "password=pscale_pw_eoAeUnn8JbYMDZWWEs9c8MduBWpYegwvrUlPNIPhqVq"
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
