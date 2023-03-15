namespace AlstefGroupTechnical.BusinessRules.Services;
public class FileSystemService : IFileSystem
{
    public FileSystemService()
    {

    }
    public bool Exists(string path)
    {
        return File.Exists(path);
    }

    public string ReadAllText(string path)
    {
        return File.ReadAllText(path);
    }

    public void WriteAllText(string path, string contents)
    {
        File.WriteAllText(path, contents);
    }
    public virtual IFileSystem GetFileSystem()
    {
        return new FileSystemService();
    }
}
