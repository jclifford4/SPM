using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Update;


namespace HashUtility
{
    public class HashUtil
    {
        public static void HashPassword()
        {
            string? username = GetUserName();
            string? password = GetUserPassword(false);

            if (username != null && password != null)
            {
                PasswordHasher<string> hasher = new PasswordHasher<string>();
                string hashedPassword = hasher.HashPassword(username, password);
                // Console.WriteLine(hashedPassword); // the hashed password result

                int attempts = 3;
                bool success = false;
                while (attempts > 0 && success == false)
                {
                    success = VerifyPassword(username, hashedPassword, attempts);
                    attempts--;
                }

                if (success == false)
                {
                    Console.WriteLine("Too many attemps try again later!");
                }
                else
                {
                    Console.WriteLine("You've succesfully created a password!");
                }
            }
            else
            {
                Console.WriteLine("An error occured!");
            }

        }

        static bool VerifyPassword(string? username, string hashedPassword, int attempts)
        {
            string? password = GetUserPassword(true);
            if (username != null && password != null)
            {
                PasswordHasher<string> hasher = new PasswordHasher<string>();
                PasswordVerificationResult result = hasher.VerifyHashedPassword(username, hashedPassword, password);
                string resultAsString = result.ToString();

                Console.WriteLine("\n" + resultAsString);
                return resultAsString != "Failed";

            }

            return false;


        }

        public static string? GetUserName()
        {
            Console.Write("Enter your username: ");
            string? username = Console.ReadLine();
            return username ?? null;
        }

        // Bool to verify copy of password against first entry;
        static string? GetUserPassword(bool hasFirstPassword)
        {

            if (!hasFirstPassword)
            {
                Console.Write("Enter a password: ");

            }
            else
            {
                Console.Write("Enter your new password: ");

            }

            string? password = ReadPassword();
            return password ?? null;

        }

        static string ReadPassword()
        {
            Console.CursorVisible = false;
            string password = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                // Ignore any key that isn't a valid input key
                if (char.IsControl(key.KeyChar))
                {
                    if (key.Key == ConsoleKey.Enter)
                    {
                        break; // Exit loop when Enter key is pressed
                    }
                    else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                    {
                        // Remove the last character from the password if Backspace is pressed
                        password = password[0..^1];
                        Console.Write("\b \b"); // Move the cursor back and erase the character
                    }
                }
                else
                {
                    password += key.KeyChar;
                    Console.Write(" "); // Print empty instead of the actual character
                }
            } while (true);
            Console.CursorVisible = true;

            return password;
        }
    }
}
