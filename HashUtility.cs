using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Update;
using UserAccount;


namespace HashUtility
{
    public class HashUtil
    {
        /// <summary>
        /// Hashes Password from user.
        /// </summary>
        /// <param name="user">User Object</param>
        /// <returns>null or String: Password Hash</returns>
        public static string? HashPassword(User user)
        {
            string? username = user.GetUserName();
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
                    return hashedPassword;
                }
            }
            else
            {
                Console.WriteLine("An error occured!");
            }

            return null;

        }


        /// <summary>
        /// Checks if current password matches previous
        /// </summary>
        /// <param name="username">string?</param>
        /// <param name="hashedPassword">string</param>
        /// <param name="attempts">int</param>
        /// <returns>bool: Same password or different</returns>
        static bool VerifyPassword(string? username, string hashedPassword, int attempts)
        {
            string? password = GetUserPassword(true);
            if (username != null && password != null)
            {
                PasswordHasher<string> hasher = new PasswordHasher<string>();
                PasswordVerificationResult result = hasher
                    .VerifyHashedPassword(username, hashedPassword, password);

                string resultAsString = result.ToString();

                Console.WriteLine("\n" + resultAsString);
                return resultAsString != "Failed";

            }

            return false;


        }

        /// <summary>
        /// Prompt user for username.
        /// </summary>
        /// <returns>null or string</returns>
        public static string? GetUserName()
        {
            Console.Write("Enter your username: ");
            string? username = Console.ReadLine();
            return username ?? null;
        }

        /// <summary>
        /// Prompt user to enter their password
        /// </summary>
        /// <param name="hasFirstPassword">bool: first password entry</param>
        /// <returns>null or string</returns>
        static string? GetUserPassword(bool hasFirstPassword)
        {

            if (!hasFirstPassword)
            {
                Console.Write("Enter a password: ");

            }
            else
            {
                Console.Write("\nEnter your new password: ");

            }

            string? password = ReadPassword();
            return password ?? null;

        }

        /// <summary>
        /// Reads key input from console
        /// </summary>
        /// <returns>Raw password</returns>
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
