using AlstefGroupTechnical.BusinessRules.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlstefGroupTechnical.BusinessRules.Models
{
    public class FileSystem : IFileSystem
    {
        public FileSystem()
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
            return new FileSystem();
        }
    }
}
