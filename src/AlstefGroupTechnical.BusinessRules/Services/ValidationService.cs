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

}


