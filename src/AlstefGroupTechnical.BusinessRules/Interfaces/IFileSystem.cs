using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlstefGroupTechnical.BusinessRules.Interfaces
{
    public interface IFileSystem
    {
        bool Exists(string path);
        string ReadAllText(string path);
        void WriteAllText(string path, string contents);
    }

}
