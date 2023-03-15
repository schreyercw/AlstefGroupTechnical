namespace AlstefGroupTechnical.BusinessRules.Services;
public static class UserInputService
{
    public static int GetValidNumberFromUser()
    {
        int userInput;

        while (true)
        {
            Console.Write("Enter a number: ");
            var input = Console.ReadLine();

            NumberValidationResultType validationResult = ValidationExtensions.ValidateNumber(input);

            if (validationResult != NumberValidationResultType.ValidNumber)
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
