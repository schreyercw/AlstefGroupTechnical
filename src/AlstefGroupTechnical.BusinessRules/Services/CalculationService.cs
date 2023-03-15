namespace AlstefGroupTechnical.BusinessRules.Services;
public static class CalculationService
{
    public static int GetTotal(int? previousValue, int userInput)
    { 
        int total = (previousValue ?? 0) + userInput;

        if (total > 152)
        {
            total -= 152;
        }
        return total;
    }
}