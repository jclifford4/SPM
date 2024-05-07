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


        private static int GetNumberOfPasswordsFromUser()
        {
            bool isValidInput = false;
            // Ask for a number of passwords to be generated.
            while (!isValidInput)
            {
                Console.WriteLine("How many passwords to you want to generate?");
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

        private static int GetLengthOfPasswordsFromUser()
        {
            // Ask for the length of the generated passwords
            bool isValidInput = false;
            while (!isValidInput)
            {

                Console.WriteLine("What length do you want your passwords to be?");
                string? userPasswordLengthInput = Console.ReadLine();

                if (userPasswordLengthInput != null)
                {
                    try
                    {
                        int number = int.Parse(userPasswordLengthInput);
                        isValidInput = true;
                        return number;
                        //     Console.WriteLine
                        //         ($"Generating {numberOfPasswords} passwords of length {passwordLength}");
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
