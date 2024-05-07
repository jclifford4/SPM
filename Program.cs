using PasswordUtility;
using UserUtily;
using HashUtility;

namespace Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // int numberOfPasswords = UserUtil.GetUserPasswordListLength();
            // int lengthOfPassowords = UserUtil.GetUserPasswordsLength();
            // UserUtil.DisplayNewCurrentPasswordList(numberOfPasswords, lengthOfPassowords);
            HashUtil.HashPassword();
        }
    }
}
