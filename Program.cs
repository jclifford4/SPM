using PasswordUtility;
using UserUtily;
using HashUtility;
using UserAccount;

namespace Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // int numberOfPasswords = UserUtil.GetUserPasswordListLength();
            // int lengthOfPassowords = UserUtil.GetUserPasswordsLength();
            // UserUtil.DisplayNewCurrentPasswordList(numberOfPasswords, lengthOfPassowords);
            // HashUtil.HashPassword();
            // User user = new User("Joseph", "", "me@mail.com", "01-12-1995");
            // User user1 = new User();
            // string userInfo = user.ToString();
            // string userInfo1 = user1.ToString();
            // Console.WriteLine(userInfo);

            User? user = UserUtil.PromptUserForInitialAccountCreation();

            if (user == null)
                Console.WriteLine("Empty User");
            else
                Console.WriteLine(user.ToString());


            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();

        }
    }
}
