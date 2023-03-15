namespace AlstefGroupTechnical.BusinessRules.Services;
public static class FileService
{
    private const string FileName = "SavedValue.txt";

    public static int GetPreviousValue()
    {
        if (!File.Exists(FileName))
        {
            return 0;
        }

        string previousValueString = File.ReadAllText(FileName);

        if (int.TryParse(previousValueString, out var previousValue))
        {
            Console.WriteLine("Previous value: {0}", previousValue);
        }
        return previousValue;
    }

    public static void SaveValueToFile(int value)
    {
        File.WriteAllText(FileName, value.ToString());
    }
}
