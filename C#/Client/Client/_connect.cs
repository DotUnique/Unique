using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace Client
{
    class _connect
    {
        private _funcs funcs;
        //DATABSE STUFF
        private const String SERVER = "";
        private const String DATABASE = "";
        private const String UID = "";
        private const String PASSWORD = @"";
        //funcs
        //METHODS
        public static void newUser(string ip, string desktop, string os)
        {
            try
            {
                string connectionString = $"Server={SERVER};Database={DATABASE};User ID={UID};Password={PASSWORD};SslMode=none";
                MySqlConnection mydbcon = new MySqlConnection(connectionString);
                mydbcon.Open();
                MySqlCommand command = mydbcon.CreateCommand();
                command.CommandText = $"INSERT INTO users SET ip ='{ip}', desktop ='{desktop}', os ='{os}'";
                IDataReader reader2 = command.ExecuteReader();
                reader2.Close();
                command.Dispose();
                mydbcon.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
    }
}
