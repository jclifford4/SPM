
namespace PasswordUtility
{
    public static class PasswordUtil
    {
        public static string Generate(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVXYZabcdefghi" +
                                "jklmnopqrstuvwxyz0123456789!?_()-+*/";
            var random = new Random();
            var passwardChars = new char[length];
            for (int i = 0; i < length; i++)
            {
                passwardChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(passwardChars);
        }
    }

}
