using FileSorterWinForm.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSorterWinForm.Repositories.Implementations
{
    internal class FileSettingsRepository : IFileSettingsRepository
    {
        public void CreateDirectoryIfMissing(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        public List<string> GetFilesExtensionsTypes(List<string> files)
        {
            var fileExtensions = new List<string>();

            files.ForEach(x =>
            {
                if (!fileExtensions.Contains(Path.GetExtension(x)))
                    fileExtensions.Add(Path.GetExtension(x));
            });

            return fileExtensions;

        }
    }
}
