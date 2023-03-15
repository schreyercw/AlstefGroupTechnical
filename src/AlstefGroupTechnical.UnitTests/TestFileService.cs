using AlstefGroupTechnical.BusinessRules.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlstefGroupTechnical.UnitTests
{
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

            var fileService = new TestableFileService(fileSystemMock.Object);

            // Act
            var result = fileService.GetPreviousValue();

            // Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void GetPreviousValue_WhenSavedValueDoesNotExist_ReturnsZero()
        {
            // Arrange
            var fileSystemMock = new Mock<IFileSystem>();
            fileSystemMock.Setup(fs => fs.Exists(It.IsAny<string>())).Returns(false);

            var fileService = new TestableFileService(fileSystemMock.Object);

            // Act
            var result = fileService.GetPreviousValue();

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void SaveValueToFile_WritesValueToFile()
        {
            const int expectedValue = 5;

            // Arrange
            var fileSystemMock = new Mock<IFileSystem>();
            var fileService = new TestableFileService(fileSystemMock.Object);

            // Act
            fileService.SaveValueToFile(expectedValue);

            // Assert
            fileSystemMock.Verify(fs => fs.WriteAllText(It.IsAny<string>(), expectedValue.ToString()), Times.Once);
        }

        private class TestableFileService : FileService
        {
            private readonly IFileSystem _fileSystem;

            public TestableFileService(IFileSystem fileSystem)
                : base(fileSystem)
            {
                _fileSystem = fileSystem;
            }

            protected override IFileSystem GetFileSystem()
            {
                return _fileSystem;
            }
        }
    }
}
