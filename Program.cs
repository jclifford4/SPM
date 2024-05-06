using PasswordUtility;
namespace Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int numberOfPasswords = GetNumberOfPasswordsFromUser();
            int lengthOfPassowrds = GetLengthOfPasswordsFromUser();
            DisplayNewPasswordList(numberOfPasswords, lengthOfPassowrds);




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
            // List all the newly ceated passwords
            for (int i = 0; i < listLength; i++)
            {
                string password = PasswordGenerator.Generate(passwordLength);
                Console.WriteLine($"{i + 1}. [pswd]: {password}");
            }
            Console.ReadLine();
        }
    }
}
