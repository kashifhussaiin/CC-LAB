using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passgen
{
    internal class Program
    {

        public static string GeneratePassword(string firstName, string lastName, string registrationNumber)
        {
            // Initials of the first and last name in uppercase
            string initials = firstName[0].ToString().ToUpper() + lastName[0].ToString().ToUpper();

            // Last two digits of the registration number
            string lastTwoDigits = registrationNumber.Substring(registrationNumber.Length - 2);

            // Generate random special characters
            string specialCharacters = GenerateRandomSpecialCharacters(2);

            // Generate random numbers
            string numbers = GenerateRandomNumbers(4);

            // Combine all elements and shuffle the password
            string password = initials + lastTwoDigits + specialCharacters + numbers;
            password = new string(password.ToCharArray().OrderBy(x => Guid.NewGuid()).ToArray());

            // Ensure the password length does not exceed 20 characters
            if (password.Length > 20)
            {
                password = password.Substring(0, 20);
            }

            return password;
        }

        private static string GenerateRandomSpecialCharacters(int count)
        {
            string specialChars = "!@#$%^&*()_-+=<>?";

            Random random = new Random();
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                int index = random.Next(specialChars.Length);
                result.Append(specialChars[index]);
            }

            return result.ToString();
        }

        private static string GenerateRandomNumbers(int count)
        {
            string numbers = "0123456789";

            Random random = new Random();
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                int index = random.Next(numbers.Length);
                result.Append(numbers[index]);
            }

            return result.ToString();
        }

        public static void Main(string[] args)
        {
            string firstName = "Tanveer";
            string lastName = "Ahmed";
            string registrationNumber = "fa20-bcs-063";

            string password = GeneratePassword(firstName, lastName, registrationNumber);
            Console.WriteLine("Generated Password: " + password);
        }
    

}
}
