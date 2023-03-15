using AlstefGroupTechnical.BusinessRules.Interfaces;
using AlstefGroupTechnical.BusinessRules.Models;

namespace AlstefGroupTechnical.BusinessRules.Services;
public class FileService
{
    
    private const string FileName = "SavedValue.txt";
    private readonly IFileSystem _fileSystem;

    public FileService(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public int? GetPreviousValue()
    {
        if (!_fileSystem.Exists(FileName))
        {
            return null;
        }

        string previousValueString = _fileSystem.ReadAllText(FileName);

        if (int.TryParse(previousValueString, out var previousValue))
        {
            Console.WriteLine("Previous value: {0}", previousValue);
        }
        return previousValue;
    }


    public void SaveValueToFile(int value)
    {
        _fileSystem.WriteAllText(FileName, value.ToString());
    }
    protected virtual IFileSystem GetFileSystem()
    {
        return new FileSystemService();
    }
}