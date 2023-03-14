namespace AlstefGroupTechnical.BusinessRules.Services;
public class FileService
{
    private const string FileName = "SavedValue.txt";

    public static int GetPreviousValue()
    {
        int previousValue = 0;

        if (File.Exists(FileName))
        {
            string previousValueString = File.ReadAllText(FileName);

            if (int.TryParse(previousValueString, out previousValue))
            {
                Console.WriteLine("Previous value: {0}", previousValue);
            }
        }

        return previousValue;
    }

    public static void SaveValueToFile(int value)
    {
        File.WriteAllText(FileName, value.ToString());
    }
}
