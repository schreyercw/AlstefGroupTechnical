﻿namespace AlstefGroupTechnical.BusinessRules.Services;
public static class UserInputService
{
    public static int GetValidNumberFromUser()
    {
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

            if (!int.TryParse(input, out var userInput))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                continue;
            }

            return userInput;
        }
    }

    public static void DisplayUpdatedTotalToUser(int updatedTotal)
    {
        Console.WriteLine($"Total: {updatedTotal}");
    }
}
