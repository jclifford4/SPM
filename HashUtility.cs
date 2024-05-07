using System.Security.Cryptography;


namespace HashUtility
{
    public class HashUtil
    {
        public static void HashPassowrd()
        {
            Console.Write("Enter a password: ");
            string? password = Console.ReadLine();

            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

        }
    }
}
