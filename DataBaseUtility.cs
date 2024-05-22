using System.Linq.Expressions;
using MySql.Data.MySqlClient;
namespace DataBaseUtility
{
    /// <summary>
    /// Encapsulate private class 'PrivateDatabaseManager.
    /// </summary>
    public class DatabaseManagerAcessor
    {
        private readonly PrivateDatabaseManager _privateDatabaseManager;

        public DatabaseManagerAcessor()
        {
            _privateDatabaseManager = new PrivateDatabaseManager();
        }

        /// <summary>
        /// Public facing database connection
        /// </summary>
        /// <returns>true or false</returns>
        public bool OpenDatabaseConnection()
        {
            return _privateDatabaseManager.Connect();
        }

        /// <summary>
        /// Public facing method to close database connection
        /// </summary>
        /// <returns>true or false</returns>
        public bool CloseDatabaseConnection()
        {
            return _privateDatabaseManager.Close();
        }

        /// <summary>
        /// Select statement from users table
        /// </summary>
        /// <returns>list[list[UserID], list[UserName], list[PasswordHash]]</returns>
        public List<string>[] Select()
        {
            return _privateDatabaseManager.Select();
        }
        /// <summary>
        /// Private Database Manager class
        /// </summary>
        class PrivateDatabaseManager
        {
            private MySqlConnection connection;
            private string server;
            private string database;
            private string uid;
            private string password;

            //Constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
            public PrivateDatabaseManager()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
            {
                Initialize();
            }

            /// <summary>
            /// Initialize server connection string
            /// </summary>
            private void Initialize()
            {
                server = "localhost";
                database = "spmdb";
                uid = "root";
                password = "FullstackDev12!";
                string connectionString;
                connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

                connection = new MySqlConnection(connectionString);
            }

            /// <summary>
            /// Encapsulate database connection
            /// </summary>
            /// <returns>true or false</returns>
            public bool Connect()
            {
                return OpenConnection();
            }
            /// <summary>
            /// Encapsulate closing databaase connection
            /// </summary>
            /// <returns>true or false</returns>
            public bool Close()
            {
                return CloseConnection();
            }

            /// <summary>
            /// Open a connection to the database.
            /// </summary>
            /// <returns>true or false</returns>
            private bool OpenConnection()
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (MySqlException ex)
                {
                    //When handling errors, you can your application's response based 
                    //on the error number.
                    //The two most common error numbers when connecting are as follows:
                    //0: Cannot connect to server.
                    //1045: Invalid user name and/or password.
                    switch (ex.Number)
                    {
                        case 0:
                            Console.WriteLine("Cannot connect to server.  Contact administrator");
                            break;

                        case 1045:
                            Console.WriteLine("Invalid username/password, please try again");
                            break;
                    }
                    return false;
                }
            }

            /// <summary>
            /// Close database connection
            /// </summary>
            /// <returns>true or false</returns>
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

            // //Insert statement
            // public void Insert()
            // {
            // }

            // //Update statement
            // public void Update()
            // {
            // }

            // //Delete statement
            // public void Delete()
            // {
            // }

            /// <summary>
            /// Request a select statement to database
            /// </summary>
            /// <returns>List<string></returns>
            public List<string>[] Select()
            {
                string query = "SELECT * FROM users";

                List<string>[] list = new List<string>[3];
                list[0] = new List<string>();   // userid
                list[1] = new List<string>();   // usernames
                list[2] = new List<string>();   // passwordhashes

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        list[0].Add(dataReader["UserID"] + "");
                        list[1].Add(dataReader["UserName"] + "");
                        list[2].Add(dataReader["MasterHash"] + "");
                    }

                    dataReader.Close();

                    this.CloseConnection();

                    return list;
                }
                else
                {
                    return list;
                }
            }

            // //Count statement
            // public int Count()
            // {
            // }

            // //Backup
            // public void Backup()
            // {
            // }

            // //Restore
            // public void Restore()
            // {
            // }
        }
    }
}
