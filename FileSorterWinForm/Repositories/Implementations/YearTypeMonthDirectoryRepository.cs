using FileSorterWinForm.Models.Files.Interfaces;
using FileSorterWinForm.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSorterWinForm.Repositories.Implementations
{
    public class YearTypeMonthDirectoryRepository : IDirectoryRepository
    {
        public void BuildFileDirectory(IFile file)
        {
            var pattern = file.CreationDate

            file.DirectoryDestinationPath = Path.Combine(file.DirectoryDestinationPath, file.CreationDate.Year.ToString(), file.CreationDate.ToString("MM"));
            if (!Directory.Exists(file.DirectoryDestinationPath))
                Directory.CreateDirectory(file.DirectoryDestinationPath);

            if (File.Exists(file.FileDestinationPath))
                fileRepository.HandleDuplicatedFileName(file);
        }
    }
}
