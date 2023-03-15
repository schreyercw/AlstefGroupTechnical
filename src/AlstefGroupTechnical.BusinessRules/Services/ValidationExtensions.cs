namespace AlstefGroupTechnical.BusinessRules.Services;
public static class ValidationExtensions
{
    //I am assuming the "number" type as an int.
    //This would have been a converstation between us for clarification of the Number type.

    public static NumberValidationResultType ValidateNumber(this string? input)
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

        return NumberValidationResultType.ValidNumber;
    }

}


