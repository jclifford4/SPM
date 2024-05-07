using PasswordUtility;
using UserUtily;
namespace Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int numberOfPasswords = UserUtil.GetUserPasswordListLength();
            int lengthOfPassowrds = UserUtil.GetUserPasswordsLength();
            UserUtil.DisplayNewCurrentPasswordList(numberOfPasswords, lengthOfPassowrds);
        }
    }
}
