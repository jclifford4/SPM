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
            DatabaseManagerAcessor dbConnect = new DatabaseManagerAcessor();
            bool running = true;
            while (running)
            {
                string mysqlDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                var user = new User();
                // Set user name
                user.UpdateUserName("steve");
                // Set password hash
                HashUtil.HashPassword(user, "poop123");
                // Insert new user to DB
                dbConnect.Insert(user.UserName, user.PasswordHash, mysqlDateTime);

                // Create new username
                string newName = "joseph";
                // get original hash
                string hash = user.PasswordHash;
                if (hash != null && newName != null)
                {
                    // if (HashUtil.VerifyMasterPassword(user) == true)
                    // {
                    string oldName = user.UserName;
                    Console.WriteLine(user.PasswordHash);
                    // Update name
                    user.UpdateUserName(newName);

                    // Make new hash
                    HashUtil.HashPassword(user, "poop123");
                    Console.WriteLine(user.PasswordHash);


                    dbConnect.Update(oldName, user.UserName, user.PasswordHash, mysqlDateTime);
                    // }



                }
                Console.WriteLine("Press 'q' to quit...");
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                if (Console.ReadLine().Equals("q"))
                {
                    running = false;
                    break;
                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }
    }
}
