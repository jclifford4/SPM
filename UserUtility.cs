using UserAccount;
using HashUtility;
using PasswordUtility;


namespace UserUtily
{
    public class UserUtil
    {
        public static int GetUserPasswordListLength()
        {
            return GetNumberOfPasswordsFromUser();
        }
        public static int GetUserPasswordsLength()
        {
            return GetLengthOfPasswordsFromUser();
        }

        public static void DisplayNewCurrentPasswordList(int listLength, int passwordsLength)
        {
            DisplayNewPasswordList(listLength, passwordsLength);
        }

        /// <summary>
        /// Prompts user to create an account. username, email, dob, hashedpassword
        /// </summary>
        /// <returns>User or null</returns>
        public static User? PromptUserForInitialAccountCreation()
        {
            User newUser = new User();
            string? newUsername = HashUtil.GetUserName();
            string? newUserPasswordHash;
            string? newUserEmail;
            string? newUserDateOfBirth;

            if (newUsername != null && newUsername != string.Empty)
            {
                newUser.UpdateUserName(newUsername);
            }
            Console.Write("Enter your email: ");
            newUserEmail = Console.ReadLine();
            Console.Write("Enter your Date of birth(MMDDYYYY): ");
            newUserDateOfBirth = Console.ReadLine();
            newUserPasswordHash = HashUtil.HashPassword(newUser);

            if (newUsername != null && newUserEmail != null && newUserDateOfBirth != null
                && newUserPasswordHash != null && newUsername != string.Empty
                && newUserEmail != string.Empty && newUserDateOfBirth != string.Empty
                && newUserPasswordHash != string.Empty)
            {
                newUser.UpdateUserName(newUsername);
                newUser.UpdateUserPasswordHash(newUserPasswordHash);
                newUser.UpdateUserEmail(newUserEmail);
                newUser.UpdateUserDateOfBirth(newUserDateOfBirth);
                return newUser;
            }

            return null;




        }

        /// <summary>
        /// Prompt user for the amount of passwords to create.
        /// </summary>
        /// <returns>int amount</returns>
        private static int GetNumberOfPasswordsFromUser()
        {
            bool isValidInput = false;
            // Ask for a number of passwords to be generated.
            while (!isValidInput)
            {
                Console.Write("How many passwords to you want to generate?\t");
                string? userInputAmount = Console.ReadLine();

                if (userInputAmount != null)
                {
                    try
                    {
                        int number = int.Parse(userInputAmount);
                        isValidInput = true;
                        return number;

                    }
                    catch (Exception ex)
                    {
                        isValidInput = false;
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine("Invalid input. Please enter a valid integer", ex);
                        Console.WriteLine("-------------------------------------------");
                    }

                }

            }

            return -1;
        }

        /// <summary>
        /// Prompt for the length of new generated password.
        /// </summary>
        /// <returns>int length</returns>
        private static int GetLengthOfPasswordsFromUser()
        {
            // Ask for the length of the generated passwords
            bool isValidInput = false;
            while (!isValidInput)
            {

                Console.Write("What length do you want your passwords to be?\t");
                string? userPasswordLengthInput = Console.ReadLine();

                if (userPasswordLengthInput != null)
                {
                    try
                    {
                        int number = int.Parse(userPasswordLengthInput);
                        isValidInput = true;
                        return number;
                    }
                    catch (Exception ex)
                    {
                        isValidInput = false;
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine("Invalid input. Please enter a valid integer", ex);
                        Console.WriteLine("-------------------------------------------");
                    }

                }

            }

            return -1;
        }

        /// <summary>
        /// Displays the specified amount of generated passwords.
        /// </summary>
        /// <param name="listLength"></param>
        /// <param name="passwordLength"></param>
        private static void DisplayNewPasswordList(int listLength, int passwordLength)
        {
            int maxLength = listLength.ToString().Length;
            // List all the newly ceated passwords
            for (int i = 1; i < listLength + 1; i++)
            {
                string password = PasswordUtil.GenerateNewPassword(passwordLength);
                if (passwordLength <= 8)
                {
                    Console.Write($"{(i).ToString().PadLeft(maxLength)}. [pswd]: {password}\t\t");

                    if (i % 4 == 0)
                        Console.WriteLine();
                }
                else if (passwordLength <= 16)
                {
                    Console.Write($"{(i).ToString().PadLeft(maxLength)}. [pswd]: {password}\t\t");
                    if (i % 3 == 0)
                        Console.WriteLine();

                }
                else
                {
                    Console.WriteLine($"{(i).ToString().PadLeft(maxLength)}. [pswd]: {password}");
                }
            }
            Console.ReadLine();
        }


    }

}
