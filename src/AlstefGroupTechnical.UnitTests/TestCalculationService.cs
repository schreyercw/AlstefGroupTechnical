namespace AlstefGroupTechnical.UnitTests;
public class TestCalculationService
{
    [Fact]
    public void CalculationService_GetTotal_ValidInput_ReturnsCorrectTotal()
    {
        // Arrange
        int previousValue = 10;
        int userInput = 20;
        int expectedTotal = 30;

        // Act
        int actualTotal = CalculationService.GetTotal(previousValue, userInput);

        // Assert
        Assert.Equal(expectedTotal, actualTotal);
    }

    [Fact]
    public void CalculationService_GetTotal_NullInput_Returns0()
    {
        //Missing No previous value in the file, would result in null.

        // Arrange
        int? previousValue = null;
        int userInput = 20;
        int expectedTotal = 20;

        // Act
        int actualTotal = CalculationService.GetTotal(previousValue, userInput);

        // Assert
        Assert.Equal(expectedTotal, actualTotal);
    }
}