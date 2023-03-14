using AlstefGroupTechnical.BusinessRules.Enums;
using System.Text.RegularExpressions;

namespace AlstefGroupTechnical.BusinessRules.Services;

public class ValidationService
{
    //I am assuming the "number" type as an int. This would have been a converstation between us for clarification of the Number type.

    public static NumberValidationResult ValidateNumber(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return NumberValidationResult.EmptyOrNullString;
        }

        foreach (char c in input)
        {
            if (!char.IsDigit(c))
            {
                return NumberValidationResult.ContainsUnknownCharacters;
            }
        }

        if (!int.TryParse(input, out int parsedInput))
        {
            return NumberValidationResult.ContainsUnknownCharacters;
        }

        if (parsedInput < int.MinValue || parsedInput > int.MaxValue)
        {
            return NumberValidationResult.OutOfRange;
        }

        return NumberValidationResult.ValidNumber;
    }
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


