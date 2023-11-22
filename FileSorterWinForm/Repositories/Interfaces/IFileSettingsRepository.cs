using FileSorterWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSorterWinForm.Repositories.Interfaces
{
    internal interface IFileSettingsRepository
    {
        List<string> GetFilesExtensionsTypes(IEnumerable<string> files);
        void CreateDirectoryIfMissing(string path);

    }
}
