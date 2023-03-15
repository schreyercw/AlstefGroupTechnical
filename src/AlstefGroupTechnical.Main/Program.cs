IFileSystem fileSystem = new FileSystemService();
IFileService fileService = new FileService(fileSystem);


//1. Ask the user to enter a number.
int userInput = UserInputService.GetValidNumberFromUser();

//2. Read the previous number that was written to disk by the program the previous time it ran.
int? previousValue = fileService.GetPreviousValue();

//3. Add the entered number to the previous number. This will give you a total number.
//4. If the total number is greater than 152 then subtract 152 from the total number.
int total = CalculationService.GetTotal(previousValue, userInput);

//5. Display the total number to the user.
UserInputService.DisplayUpdatedTotalToUser(total);

//6. Save the total number to disk.
fileService.SaveValueToFile(total);

//7. Exit.
Environment.Exit(0);