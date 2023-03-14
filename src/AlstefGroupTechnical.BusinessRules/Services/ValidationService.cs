namespace AlstefGroupTechnical.BusinessRules.Services;

public class ValidationService
{
    //I am assuming the "number" type as an int. This would have been a converstation between us for clarification of the Number type.

    public static NumberValidationResultType ValidateNumber(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return NumberValidationResultType.EmptyOrNullString;
        }

        foreach (char c in input)
        {
            if (!char.IsDigit(c))
            {
                return NumberValidationResultType.ContainsUnknownCharacters;
            }
        }

        if (!int.TryParse(input, out int parsedInput))
        {
            return NumberValidationResultType.ContainsUnknownCharacters;
        }

        if (parsedInput < int.MinValue || parsedInput > int.MaxValue)
        {
            return NumberValidationResultType.OutOfRange;
        }

        if (parsedInput < int.MinValue || parsedInput > int.MaxValue)
        {
            return NumberValidationResultType.OutOfRange;
        }

        return NumberValidationResultType.ValidNumber;
    }

}


