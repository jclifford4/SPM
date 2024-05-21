using MySql.Data.MySqlClient;
namespace DataBaseUtility
{
    public static class DataBaseUtil
    {

        public static bool TestDBConnection()
        {
            string server = "localhost";
            // string port = "3306";
            string username = "root";
            string password = "FullstackDev12!";
            string database = "spmdb";
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            // string query = "SELECT * FROM users";



            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        Console.WriteLine("Connected to database.");
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred while trying to connect to the database:");
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }
            }
        }



    }
}
