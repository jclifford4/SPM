using PasswordUtility;
using UserUtily;
using HashUtility;
using UserAccount;
using DataBaseUtility;

namespace Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // List<User> users = new List<User>();

            // Console.WriteLine("--------------------------------------");
            // Console.WriteLine("Welcome to the Secure Password Manager!");
            // Console.WriteLine("Here you can:");
            // Console.WriteLine("1. Have Individual secure accounts\n2. Save passwords securily");
            // Console.WriteLine("3. Update passwords securily\n4. Remove passwords securily");
            // Console.WriteLine("--------------------------------------");
            // // Console.WriteLine("To get started all you need is to make a local account on your computer.");
            // string menuTips = "[('h' help), ('q' quit)]";
            // string consoleContext = "[spm]: ";
            // Console.WriteLine($"\t{menuTips}");
            // Console.Write(consoleContext);

            // bool isActive = true;
            // string? menuInput = Console.ReadLine();
            // while (isActive)
            // {


            //     string? usernameInput = string.Empty;
            //     switch (menuInput)
            //     {
            //         case "ad":
            //             Console.Write("Enter a username: ");
            //             usernameInput = Console.ReadLine();
            //             if (usernameInput != null)
            //             {
            //                 try
            //                 {
            //                     User? user = users.FirstOrDefault(u => u.UserName.Equals(usernameInput));
            //                     if (user != null)
            //                         UserUtil.PromptUserForNewItemGeneration(user);

            //                 }
            //                 catch (Exception ex)
            //                 {
            //                     Console.WriteLine($"Error finding specified user {usernameInput}", ex);
            //                 }

            //             }
            //             break;
            //         case "q":
            //             isActive = false;
            //             break;
            //         case "h":
            //             Console.WriteLine("\n----------");
            //             Console.WriteLine("ad - Create a new password");
            //             Console.WriteLine("ch - Change a user password");
            //             Console.WriteLine("cl - To clear the console");
            //             Console.WriteLine("cr - Initializes new user account creation");
            //             Console.WriteLine("kl - Delete a user account and all associated passwords");
            //             Console.WriteLine("li - List all saved named items from a specific user");
            //             Console.WriteLine("lg - Log in as a user");
            //             Console.WriteLine("lu - List all users on this machine");
            //             Console.WriteLine("q - quit application");
            //             Console.WriteLine("rm - Delete a user password");
            //             Console.WriteLine("ts - test master");
            //             Console.WriteLine("----------\n");
            //             break;
            //         case "cl":
            //             Console.Clear();
            //             break;
            //         case "cr":
            //             try
            //             {
            //                 User? user = UserUtil.PromptUserForInitialAccountCreation();
            //                 if (user != null)
            //                     users.Add(user);

            //             }
            //             catch (Exception ex)
            //             {
            //                 Console.WriteLine("There was an error creating a new user.", ex);
            //             }
            //             break;

            //         case "lu":
            //             foreach (var user in users)
            //                 Console.WriteLine(user.GetUserName());
            //             break;

            //         case "li":
            //             Console.Write("Enter a username: ");
            //             usernameInput = Console.ReadLine();
            //             if (usernameInput != null)
            //             {
            //                 try
            //                 {
            //                     User? user = users.FirstOrDefault(u => u.UserName.Equals(usernameInput));
            //                     if (user != null)
            //                     {
            //                         Console.WriteLine("----------");
            //                         user.ListAllSavedUserItemNames();
            //                         Console.WriteLine("----------");

            //                     }
            //                 }
            //                 catch (Exception ex)
            //                 {
            //                     Console.WriteLine($"Error finding specified user {usernameInput}", ex);
            //                 }

            //             }
            //             break;
            //         case "lg":
            //             Console.Write("Username: ");
            //             usernameInput = Console.ReadLine() ?? "";
            //             bool isLoggedIn = false;
            //             try
            //             {
            //                 User? user = users.FirstOrDefault(u => u.UserName.Equals(usernameInput));
            //                 if (user != null)
            //                 {
            //                     isLoggedIn = HashUtil.VerifyMasterPassword(user);
            //                 }
            //                 if (isLoggedIn)
            //                     Console.WriteLine("You are logged in");
            //             }
            //             catch (Exception ex)
            //             {
            //                 Console.WriteLine("Error Logging in", ex);
            //             }
            //             break;

            //         default:
            //             break;
            //     }


            //     Console.Write(consoleContext);
            //     if (menuInput != "q")
            //         menuInput = Console.ReadLine();
            // }



            // var user1 = new User();
            // user.UpdateUserName("bob");
            // Console.WriteLine(HashUtil.PromptAndHashNewUserPassword(user1));


            // PasswordManager passwordManager = new PasswordManager();
            // // Console.WriteLine(EncryptionUtility.GenerateSecureKey());

            // // Store a password
            // passwordManager.StorePassword("Netflix", "mySecurePassword123");
            // // Retrieve and decrypt the password
            // // passwordManager.RetrievePassword("Netflix");
            // passwordManager.StorePassword("Gmail", ";3;l!!!'jl;kj213asdfl;sdf");

            // // Retrieve and decrypt the password
            // // passwordManager.RetrievePassword("Gmail");

            // passwordManager.StorePassword("Facebook", "mySecurePassword800");
            // Retrieve and decrypt the password
            // passwordManager.RetrievePassword("Facebook");

            DatabaseManagerAcessor dbConnect = new DatabaseManagerAcessor();
            bool running = true;
            while (running)
            {
                var user = new User();
                Console.Write("username: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string name = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string hash = HashUtil.PromptAndHashNewUserPassword(user);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                if (name != null && hash != null)
                {
                    // user.UpdateUserName(name);
                    // user.UpdateUserPasswordHash(hash);
                    string mysqlDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    dbConnect.Insert(name, hash, mysqlDateTime);
                    // dbConnect.OpenDatabaseConnection();
                    // dbConnect.CloseDatabaseConnection();
                    // List<string>[] lists = dbConnect.Select();

                    // Console.WriteLine("Before deletion");
                    // for (int i = 0; i < lists.Length - 1; i++)
                    // {
                    //     Console.WriteLine($"{lists[0][i]} {lists[1][i]} {lists[2][i]}");



                    // }


                    // dbConnect.Delete("bill");
                    // lists = dbConnect.Select();
                    // Console.WriteLine("After deletion");
                    // for (int i = 0; i < lists.Length - 1; i++)
                    // {
                    //     Console.WriteLine($"{lists[0][i]} {lists[1][i]} {lists[2][i]}");



                    // }
                    // dbConnect.Update(name, hash, dateTime);


                }
                Console.WriteLine("Press 'q' to quit...");
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                if (Console.ReadLine().Equals("q"))
                {
                    break;
                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
            // dbConnect.Update("joseph", "AQAAAAIAAYagAAAAEBTRKjwaHLYKptHkDwW3E/6xOrsnueLl2XncbqZxEgpGGvX9ITcuwDTC7EzsvT620A==", mysqlDateTime);
            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }
    }
}
