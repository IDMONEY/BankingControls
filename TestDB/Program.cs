using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace TestDB
{
    class Program
    {
        static void Main(string[] args)
        {

            int counter = 150000;
            for (int i = 0; i < counter; i++)
            {
                insertCustomer();
            }

        }

        static void insertCustomer()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 10);

            string connStr = ConfigurationManager.ConnectionStrings["dbConnectionRAFMain"].ConnectionString;
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr))
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "CALL proc_insertTestData(" + randomNumber + ");";
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }

    }
}
