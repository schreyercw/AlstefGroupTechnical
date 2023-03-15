using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlstefGroupTechnical.BusinessRules.Interfaces
{
    public interface IFileService
    {
        int? GetPreviousValue();
        void SaveValueToFile(int value);
    }
}
