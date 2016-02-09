using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace nugetTest
{
    class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string password;
        private string userName;

        static void Main(string[] args)
        {
            DBConnect x = new DBConnect();
            x.Initialize();

            if (x.OpenConnection())
            {
                Console.WriteLine("Yay, it worked!\nPress any key to finish test.");
                Console.Read();
                x.CloseConnection();
            }

            //x.Insert();

            Console.WriteLine("Reached end of main, press any key to exit program.");
            Console.Read();
        }

        private void Initialize()
        {
            Console.WriteLine("Entered Initialize");
            server = ""; //HEY PUT THE THINGIE HERE!
            database = "test";
            password = ""; // AND HERE! #SMILEYFACE
            userName = "application"; 
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + userName + ";" + "PASSWORD=" + password + ";";

            try
            {
                connection = new MySqlConnection(connectionString);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Exiting Initialize");
        }

        private bool OpenConnection()
        {
            try
            {
                Console.WriteLine("Trying to open connection.");
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect. That sucks.\nError Unknown: Ask Chris what went wrong.");
                        break;

                    case 1045:
                        Console.WriteLine("Cannot connect. That sucks.\nError 1045: Ask Chris what went wrong.");
                        break;
                }
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public void Insert()
        {
            string query = "INSERT INTO test1 VALUES(NULL)";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
    }
}
