namespace AlstefGroupTechnical.UnitTests;
public class TestValidationService
{
    [Fact]
    public void ValidateNumber_NullInput_ReturnsInvalidResult()
    {
        // Arrange
        string? input = null;

        // Act
        var result = ValidationExtensions.ValidateNumber(input);

        // Assert
        Assert.Equal(NumberValidationResultType.EmptyOrNullString, result);
    }

    [Fact]
    public void ValidateNumber_EmptyString_ReturnsInvalidResult()
    {
        // Arrange
        string? input = string.Empty;

        // Act
        var result = input.ValidateNumber();

        // Assert
        Assert.Equal(NumberValidationResultType.EmptyOrNullString, result);
    }


    [Theory]
    [InlineData("123$#%", NumberValidationResultType.ContainsUnknownCharacters)]
    [InlineData("abc123", NumberValidationResultType.ContainsUnknownCharacters)]
    [InlineData("    ", NumberValidationResultType.EmptyOrNullString)]
    [InlineData("123", NumberValidationResultType.ValidNumber)]
    public void ValidateNumber(string? input, NumberValidationResultType expected)
    {
        // Arrange

        // Act
        var result = ValidationExtensions.ValidateNumber(input);

        // Assert
        Assert.Equal(expected, result);
    }
}