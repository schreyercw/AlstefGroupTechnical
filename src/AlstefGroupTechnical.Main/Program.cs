
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