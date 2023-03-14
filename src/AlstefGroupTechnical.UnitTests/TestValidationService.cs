namespace AlstefGroupTechnical.UnitTests;
public class TestValidationService
{

    public void ValidateNumber_ValidNumber_ReturnsValidResult()
    {
        // Arrange
        string input = "123";

        // Act
        var result = ValidationService.ValidateNumber(input);

        // Assert
        Assert.Equal(NumberValidationResultType.ValidNumber, result);
    }
    [Fact]
    public void ValidateNumber_NullInput_ReturnsInvalidResult()
    {
        // Arrange
        string input = null;

        // Act
        var result = ValidationService.ValidateNumber(input);

        // Assert
        Assert.Equal(NumberValidationResultType.EmptyOrNullString, result);
    }

    [Fact]
    public void ValidateNumber_EmptyString_ReturnsInvalidResult()
    {
        // Arrange
        string input = string.Empty;

        // Act
        var result = ValidationService.ValidateNumber(input);

        // Assert
        Assert.Equal(NumberValidationResultType.EmptyOrNullString, result);
    }

    [Fact]
    public void ValidateNumber_WhitespaceString_ReturnsInvalidResult()
    {
        // Arrange
        string input = "    ";

        // Act
        var result = ValidationService.ValidateNumber(input);

        // Assert
        Assert.Equal(NumberValidationResultType.EmptyOrNullString, result);
    }

    [Fact]
    public void ValidateNumber_ContainsLetters_ReturnsInvalidResult()
    {
        // Arrange
        string input = "abc123";

        // Act
        var result = ValidationService.ValidateNumber(input);

        // Assert
        Assert.Equal(NumberValidationResultType.ContainsUnknownCharacters, result);
    }

    [Fact]
    public void ValidateNumber_ContainsSpecialCharacters_ReturnsInvalidResult()
    {
        // Arrange
        string input = "123$#%";

        // Act
        var result = ValidationService.ValidateNumber(input);

        // Assert
        Assert.Equal(NumberValidationResultType.ContainsUnknownCharacters, result);
    }

    [Fact]
    public void ValidateNumber_OutOfRange_ReturnsInvalidResult()
    {
        // Arrange
        string input = "2147483648"; // int.MaxValue + 1

        // Act
        var result = ValidationService.ValidateNumber(input);

        // Assert
        Assert.Equal(NumberValidationResultType.OutOfRange, result);
    }

}