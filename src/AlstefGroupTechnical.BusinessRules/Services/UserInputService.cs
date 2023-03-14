

namespace AlstefGroupTechnical.BusinessRules.Services
{
    public class UserInputService
    {
        public static int GetValidNumberFromUser()
        {
            int userInput;

            while (true)
            {
                Console.Write("Enter a number: ");
                string input = Console.ReadLine();

                NumberValidationResult validationResult = ValidationService.ValidateNumber(input);

                if (validationResult != NumberValidationResult.ValidNumber)
                {
                    Console.WriteLine($"Invalid input. {validationResult}. Please enter a valid number.");
                    continue;
                }

                if (!int.TryParse(input, out userInput))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }

                return userInput;
            }
        }
    }
}
