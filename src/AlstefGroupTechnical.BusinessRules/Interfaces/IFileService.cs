namespace AlstefGroupTechnical.BusinessRules.Interfaces;
public interface IFileService
{
    int? GetPreviousValue();
    void SaveValueToFile(int value);
}
