# AlstefGroupTechnical

The following readme is the outline of the project for the Technical test for AlstefGroup.


------------

##### Requirements:

Every time the program is run it must do the following:

1.  Ask the user to enter a number.
2.  Read the previous number that was written to disk by the program the previous time it ran.
3.  Add the entered number to the previous number. This will give you a total number.
4.  If the total number is greater than 152 then subtract 152 from the total number.
5.  Display the total number to the user.
6.  Save the total number to disk.
7.  Exit.
#### Project Task List
- [x] 1. Created an empty Github repo called AlstefGroup_Technical
- [x] 2. Cloned it to my machine.
- [x] 3. Scaffold Git Structure
- [x] 4. Set up Git Readme

------------


###### Solution Project Structure:  
1. Created a blank solution file called `AlstefGroupTechnical.sln`
2. Created a Console Application project called `AlstefGroupTechnical.Main` to host the application.
3. Created a xUnit Test project called `AlstefGroupTechnical.UnitTests` to host the unit tests.
4. Created a Class Library project called `AlstefGroupTechnical.BusinessRules` to encapsulate the business logic.

###### Project References:
  - [x] Referenced `AlstefGroupTechnical.BusinessRules` from `AlstefGroupTechnical.Main`
  - [x] Referenced `AlstefGroupTechnical.BusinessRules` from `AlstefGroupTechnical.UnitTests`

------------
### Enums:
- NumberValidationResultType:

        1.ValidNumber
        2.EmptyOrNullString
        3.ContainsUnknownCharacters
        4.NegativeNumber
### Models:
- NumberValidationResult
```C#
    public bool IsValid => ErrorMessage is not null;
    public int? ValidatedNumber { get; set; }
    public string? ErrorMessage { get; set; }
    public NumberValidationResultType ResultType { get; set; }
```
### Interfaces:
- IFileService
```c#
    int? GetPreviousValue();
    void SaveValueToFile(int value);
```
- IFileSystem
```c#
    bool Exists(string path);
    string ReadAllText(string path);
    void WriteAllText(string path, string contents);
```

### Services:
- CalculationService
- FileService
- FileSystemService
- UserInputService
- ValidationExtensions

### Tests:
- TestCalculationService
```C#
CalculationService_GetTotal_ValidInput_ReturnsCorrectTotal()
{
    //Inputs:
    int previousValue = 10;
    int userInput = 20;
    int expectedTotal = 30;

    //Outputs:
    Assert.Equal(expectedTotal, actualTotal);
}
```
- TestFileService
```C#
GetPreviousValue_WhenSavedValueExists_ReturnsSavedValue()
{
    //Testing the correct progression of the services that when it gets a value, it returns the correct value.

    //Inputs: 
    const int inputValue = 5;

    //Outputs:
    Assert.Equal(inputValue, result);
}
public void GetPreviousValue_WhenSavedValueDoesNotExist_ReturnsNull()
{
    //Calling this Test will test the Exists and GetPreviousValue Methods and if it returns Null.

    //Inputs: 
    var fileSystemMock = new Mock<IFileSystem>();
    fileSystemMock.Setup(fs => fs.Exists(It.IsAny<string>())).Returns(false);

    //Outputs:
    Assert.Null(result);
}
public void SaveValueToFile_CallsWriteAllText()
{
    //Calling this Test will test the WriteAllText Method and if it calls correctly from IFileSystem.

    //Inputs: 
    const int inputValue = 5;

    //Outputs:
    fileSystemMock.Verify(fs => fs.WriteAllText(It.IsAny<string>(), inputValue.ToString()), Times.Once);
}
```
- TestValidationService
```C#
public void ValidateNumber_NullInput_ReturnsInvalidResult()
{
    //Calling this will test if a null input returns the correct NumberValidationResultType

    //Inputs: 
    string? input = null;

    //Outputs:
    Assert.Equal(NumberValidationResultType.EmptyOrNullString, result);
}
public void ValidateNumber_EmptyString_ReturnsInvalidResult()
{
    //Calling this will test if a null input returns the correct NumberValidationResultType

    //Inputs: 
    string? input = string.Empty;

    //Outputs:
    Assert.Equal(NumberValidationResultType.EmptyOrNullString, result);
}
public void ValidateNumber(string? input, NumberValidationResultType expected)
{
    //Inputs:
    [InlineData("123$#%", NumberValidationResultType.ContainsUnknownCharacters)]
    [InlineData("abc123", NumberValidationResultType.ContainsUnknownCharacters)]
    [InlineData("    ", NumberValidationResultType.EmptyOrNullString)]
    [InlineData("123", NumberValidationResultType.ValidNumber)]
    //Outputs:
    Assert.Equal(expected, result);
}
```

## Program.cs:
```C#
IFileSystem fileSystem = new FileSystemService();
FileService fileService = new FileService(fileSystem);

// Get previous value from file if it exists
int? previousValue = fileService.GetPreviousValue();

// Get new value from user
int userInput = UserInputService.GetValidNumberFromUser();

// Calculate new total value
int total = CalculationService.GetTotal(previousValue ?? 0, userInput);

// Save new value to file
fileService.SaveValueToFile(total);
```

## Requirements Completed:
- [x] 1.  Ask the user to enter a number. 
- [x] 2.  Read the previous number that was written to disk by the program the previous time it ran. 
- [x] 3.  Add the entered number to the previous number. This will give you a total number. 
- [x] 4.  If the total number is greater than 152 then subtract 152 from the total number. 
- [x] 5.  Display the total number to the user. 
- [x] 6.  Save the total number to disk.
- [x] 7.  Exit. 

### Additional Notes:
The project took approximately `12 hours` to do.

Thank you for the opportunity to work on this project.

Charles Schreyer