using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateRemoval.Core.Infrastructure
{
    public interface IFileManager
    {
        bool FileExists(string fileName);
        void SaveFileData(string fileName, IList<string> fileData);
        IList<string> GetFileData(string fileName);
    }
}
