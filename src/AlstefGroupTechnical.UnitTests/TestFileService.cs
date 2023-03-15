namespace AlstefGroupTechnical.UnitTests;
public class TestFileService
{
    [Fact]
    public void GetPreviousValue_WhenSavedValueExists_ReturnsSavedValue()
    {
        //Testing the correct progression of the test that when it gets a value, it returns the correct value.
        const int inputValue = 5;

        // Arrange
        var fileSystemMock = new Mock<IFileSystem>();
        fileSystemMock.Setup(fs => fs.Exists(It.IsAny<string>())).Returns(true);
        fileSystemMock.Setup(fs => fs.ReadAllText(It.IsAny<string>())).Returns(inputValue.ToString());

        var fileService = new FileService(fileSystemMock.Object);

        // Act
        var result = fileService.GetPreviousValue();

        // Assert
        Assert.Equal(inputValue, result);
    }

    [Fact]
    public void GetPreviousValue_WhenSavedValueDoesNotExist_ReturnsNull()
    {
        //Calling this Test will test the Exists and GetPreviousValue Methods and if it returns Null.
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
        //Calling this Test will test the WriteAllText Method and if it calls correctly from IFileSystem.
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
