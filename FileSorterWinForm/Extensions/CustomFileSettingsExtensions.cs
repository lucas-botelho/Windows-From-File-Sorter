using FileSorterWinForm.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSorterWinForm.Extensions
{
    public static class CustomFileSettingsExtensions
    {
        public static void HandleDuplicatedFileName(this CustomFileSettings fileSettings)
        {
            var repeatedFileCount = 1;

            while (File.Exists(fileSettings.FullDestinationPath))
            {
                if (repeatedFileCount == 1)
                    fileSettings.FileName += $"({++repeatedFileCount})";
                else
                    fileSettings.FileName = fileSettings.FileName.Replace($"({repeatedFileCount})", $"({++repeatedFileCount})");

                fileSettings.FullDestinationPath = fileSettings.FullDestinationPath.Replace(Path.GetFileNameWithoutExtension(fileSettings.FullDestinationPath), fileSettings.FileName);
            }
        }
    }
}
