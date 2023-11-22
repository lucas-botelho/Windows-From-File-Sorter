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

        public List<string> GetFilesExtensionsTypes(IEnumerable<string> files)
        {
            var fileExtensions = new List<string>();

            foreach (var file in files)
            {
                if (!fileExtensions.Contains(Path.GetExtension(file)))
                    fileExtensions.Add(Path.GetExtension(file));
            }

            return fileExtensions;

        }
    }
}
