namespace AlstefGroupTechnical.UnitTests;

public class FileServiceTests
{
    [Fact]
    public void GetPreviousValue_WhenSavedValueExists_ReturnsSavedValue()
    {
        const int expectedValue = 5;

        // Arrange
        var fileSystemMock = new Mock<IFileSystem>();
        fileSystemMock.Setup(fs => fs.Exists(It.IsAny<string>())).Returns(true);
        fileSystemMock.Setup(fs => fs.ReadAllText(It.IsAny<string>())).Returns(expectedValue.ToString());

        var fileService = new FileService(fileSystemMock.Object);

        // Act
        var result = fileService.GetPreviousValue();

        // Assert
        Assert.Equal(expectedValue, result);
    }

    [Fact]
    public void GetPreviousValue_WhenSavedValueDoesNotExist_ReturnsNull()
    {
        // Arrange
        var fileSystemMock = new Mock<IFileSystem>();
        fileSystemMock.Setup(fs => fs.Exists(It.IsAny<string>())).Returns(false);

        var fileService = new FileService(fileSystemMock.Object);

        // Act
        var result = fileService.GetPreviousValue();
        
        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void SaveValueToFile_CallsWriteAllText()
    {
        //When I call the WriteAllText Method it calls correctly from IFileSystem
        const int inputValue = 5;

        // Arrange
        var fileSystemMock = new Mock<IFileSystem>();
        var fileService = new FileService(fileSystemMock.Object);

        // Act
        fileService.SaveValueToFile(inputValue);

        // Assert
        fileSystemMock.Verify(fs => fs.WriteAllText(It.IsAny<string>(), inputValue.ToString()), Times.Once);
    }
}
