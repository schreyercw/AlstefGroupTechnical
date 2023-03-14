namespace AlstefGroupTechnical.BusinessRules.Services;
public class CalculationService
{
    public static int GetTotal(int previousValue, int userInput)
    { 
        int total = previousValue + userInput;

        if (total > 152)
        {
            total -= 152;
        }
        return total;
    }
}